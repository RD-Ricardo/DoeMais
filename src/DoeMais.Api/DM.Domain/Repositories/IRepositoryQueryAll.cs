using DM.Core.Data;
using DM.Core.DomainObjects;

namespace DM.Domain.Repositories
{
    public interface IRepositoryQueryAll<TEntity> : IDisposable, IRepositoryQuery<TEntity> where TEntity : Entity
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        IUnitOfWork UnitOfWork { get; }
    }
}
