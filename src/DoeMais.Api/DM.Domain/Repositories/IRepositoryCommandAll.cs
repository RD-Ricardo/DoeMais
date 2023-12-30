using DM.Core.DomainObjects;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DM.Domain.Repositories
{
    public interface IRepositoryCommandAll<TEntity> : IRepositoryComand<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> FindById(Guid id, bool leitura = false, params string[] includes);
        Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes);
        Task<IEnumerable<TResult>> FindBy<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes);
        Task<TResult> FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes);
        Task<bool> Any(Expression<Func<TEntity, bool>> filtro, params string[] includes);
        IQueryable<TEntity> Query(bool leitura = false, params string[] includes);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes);
    }
}
