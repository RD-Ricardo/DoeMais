using DM.Core.Data;
using DM.Core.DomainObjects;
using System.Linq.Expressions;

namespace DM.Domain.Repositories
{
    public interface IRepositoryQuery<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> FindById(Guid id);
        Task<IEnumerable<TEntity>> GetAllWhere(Expression<Func<TEntity, bool>> filter);
    }
}
