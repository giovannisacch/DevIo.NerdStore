using System;
using System.Threading.Tasks;
using DevIo.NerdStore.Catalogo.Domain.events;
using DevIo.NerdStore.Core.Mediatr;

namespace DevIo.NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _mediatr;
        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler mediatr)
        {
            _produtoRepository = produtoRepository;
            _mediatr = mediatr;
        }
        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);
            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;
            
            produto.DebitarEstoque(quantidade);
            
            //TODO: Parametrizar qtd de estoque baixo
            if (produto.QuantidadeEstoque < 10)
            {
                // Notificar responsavel, abrir chamado, realizar nova compra por exemplo nao sao responsabilidades dessa classe
                // Apenas publica evento falando que isso aconteceu e o que deve ser feita com essa informacao nao interessa aqui
                
                await _mediatr.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);
            if (produto == null) return false;
            produto.ReporEstoque(quantidade);
            
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
    
}