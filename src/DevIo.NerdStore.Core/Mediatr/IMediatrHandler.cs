using System.Threading.Tasks;
using DevIo.NerdStore.Core.Messages;

namespace DevIo.NerdStore.Core.Mediatr
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}