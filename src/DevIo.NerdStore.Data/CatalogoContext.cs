using System;
using System.Linq;
using System.Threading.Tasks;
using DevIo.NerdStore.Catalogo.Domain;
using DevIo.NerdStore.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace DevIo.NerdStore.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options
        ) : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
            //Metodo acima pega as configuracoes das classes que estao com o DbSet
        }
        
        public async Task<bool> Commit()
        {
            //Garantindo que atualizo/crio uma data de cadastro sempre que commito um objeto que tenha essa propriedade
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            
            return await base.SaveChangesAsync() > 0;        
        }
    }
}