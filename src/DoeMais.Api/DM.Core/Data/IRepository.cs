using DM.Core.DomainObjects;

namespace DM.Core.Data
{
    public interface IRepository<TRepository> where TRepository : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
