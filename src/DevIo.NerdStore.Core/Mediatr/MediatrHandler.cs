using System.Threading.Tasks;
using DevIo.NerdStore.Core.Mediatr;
using DevIo.NerdStore.Core.Messages;
using MediatR;

namespace DevIo.NerdStore.Core.Mediatr
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            //Basicamente para facilitar o entendimento(TIPO um facade)
            //*Facade é utilizado para traduzir chamadas em servicos externos para uma linguagem conhecida
            await _mediator.Publish(evento);
        }
    }
}