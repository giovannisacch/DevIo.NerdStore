using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevIo.NerdStore.Core.Messages;
using DevIo.NerdStore.Vendas.Domain;
using MediatR;

namespace DevIo.NerdStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler : CommandHandler, IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(message.ClienteId);
            var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);

            if (pedido == null)
            {
                pedido = Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId);
                pedido.AdicionarItem(pedidoItem);
                
                _pedidoRepository.Adicionar(pedido);
            }
            else
            {
                var pedidoItemExistente = pedido.PedidoItemExistente(pedidoItem);
                pedido.AdicionarItem(pedidoItem);

                if (pedidoItemExistente)
                    _pedidoRepository.AtualizarItem(pedido.PedidoItems
                        .FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId));
                else
                    _pedidoRepository.AdicionarItem(pedidoItem);
            }
            
            return await _pedidoRepository.UnitOfWork.Commit();
        }
    }
}