using DM.Core.Data;
using DM.Core.DomainObjects;

namespace DM.Domain.Repositories
{
    public interface IRepositoryComand<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
