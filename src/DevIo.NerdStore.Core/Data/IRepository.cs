using System;
using DevIo.NerdStore.Core.DomainObjects.Interfaces;

namespace DevIo.NerdStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        //Com essa heranca garanto que so terei um repositorio por agregacao(regra do DDD) e esse repositorio vai ser usando a raiz
        IUnitOfWork UnitOfWork { get; }
    }
    
}