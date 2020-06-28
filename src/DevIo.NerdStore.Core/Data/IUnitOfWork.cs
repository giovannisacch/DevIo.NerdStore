using System.Threading.Tasks;

namespace DevIo.NerdStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}