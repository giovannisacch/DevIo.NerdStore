using System.Collections.Generic;
using DevIo.NerdStore.Core.DomainObjects;

namespace DevIo.NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        
        public ICollection<Produto> Produtos { get; set; }

        protected  Categoria(){}
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome da categoria nao pode estar nulo");
            Validacoes.ValidarSeMenorQue(Codigo, 0, "O campo codigo nao pode ser menos que zero");

        }
    }
}