using System;
using System.Collections;
using DevIo.NerdStore.Core.DomainObjects;
using DevIo.NerdStore.Core.DomainObjects.Interfaces;

namespace DevIo.NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        //IAggregateRoot esta sendo usada como uma Interface de marcação apenas para identificar que e a raiz de uma agregacao
        public string Nome { get; private set; }    
        public string Descricao { get; private set; }    
        public bool Ativo { get; private set; }    
        public decimal Valor { get; private set; }  
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Dimensoes Dimensoes { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
            Dimensoes = dimensoes;
            Validar();
        }

        protected Produto()
        {
            
        }
        //AdHoc Setters
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }
        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if(!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            quantidade += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor do produto não pode se menor igual a 0");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");

        }
    }
}