using System;
using System.Collections.Generic;
using System.Xml.Schema;
using DevIo.NerdStore.Catalogo.Domain;
using DevIo.NerdStore.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace DevIo.NerdStore.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adesivoCategoria = new Categoria("Adesivos", 102);
            var camisetaCategoria = new Categoria("Camisetas", 100);
            var canecaCategoria = new Categoria("Canecas", 101);
            
            modelBuilder.Entity<Categoria>().HasData(
                adesivoCategoria,
                camisetaCategoria,
                canecaCategoria
            );
            
            var descricaoPadraoCamiseta = "Camiseta 100% algodão";
            var descricaoPadraoCaneca = "Caneca de porcelana";

            var dimensaoPadraoCaneca = new Dimensoes(12, 8, 5);
            var dimensaoPadraoCamiseta = new Dimensoes(5, 5, 5);

            
            var produtosParaAdicionar = new List<Produto>
            {
                new Produto("Camiseta Code life preta", descricaoPadraoCamiseta, true,
                    90, camisetaCategoria.Id, DateTime.Now, "camiseta2.jpg", dimensaoPadraoCamiseta),
                new Produto("Caneca no coffe no code", descricaoPadraoCaneca, true,
                    10, canecaCategoria.Id, DateTime.Now, "caneca4.jpg", dimensaoPadraoCaneca),
                new Produto("Camiseta Debug", descricaoPadraoCamiseta, true,
                    110, camisetaCategoria.Id, DateTime.Now, "camiseta4.jpg", dimensaoPadraoCamiseta),
                new Produto("Camiseta Code life branca", descricaoPadraoCamiseta, true,
                    80, camisetaCategoria.Id, DateTime.Now, "camiseta3.jpg", dimensaoPadraoCamiseta),
                new Produto("Caneca Star bucks", descricaoPadraoCaneca, true,
                    20, canecaCategoria.Id, DateTime.Now, "caneca1.jpg", dimensaoPadraoCaneca),
                new Produto("Caneca Prgramador", descricaoPadraoCaneca, true,
                    20, canecaCategoria.Id, DateTime.Now, "caneca2.jpg", dimensaoPadraoCaneca),
                new Produto("Camiseta Software", descricaoPadraoCamiseta, true,
                    80, camisetaCategoria.Id, DateTime.Now, "camiseta1.jpg", dimensaoPadraoCamiseta),
                new Produto("Caneca Turn code", descricaoPadraoCaneca, true,
                    20, canecaCategoria.Id, DateTime.Now, "caneca3.jpg", dimensaoPadraoCaneca)
            };
            modelBuilder.Entity<Produto>(prd =>
            {
                foreach (var produtoParaAdiciconar in produtosParaAdicionar)
                {
                    prd.HasData(produtoParaAdiciconar.MapearProdutoParaObjAnonimo());
                    prd.OwnsOne(x => x.Dimensoes)
                        .HasData(produtoParaAdiciconar.MapearDimensaoDoProdutoParaObjAnonimo());
                }
            });
        }
           
        private static object MapearProdutoParaObjAnonimo(this Produto obj)
        {
            return new
            {
                obj.Id,
                obj.CategoriaId,
                obj.Nome,
                obj.Descricao,
                obj.Ativo,
                obj.Valor,
                obj.DataCadastro,
                obj.Imagem,
                obj.QuantidadeEstoque
            };
        }

        private static object MapearDimensaoDoProdutoParaObjAnonimo(this Produto obj)
        {
            return new
            {
                ProdutoId = obj.Id,
                obj.Dimensoes.Altura,
                obj.Dimensoes.Largura,
                obj.Dimensoes.Profundidade
            };
        }
    }
}