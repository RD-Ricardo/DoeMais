using DM.Core.Data;
using DM.Core.DomainObjects;
using DM.Domain.Repositories;
using DM.Infrastructure.Data.CommandsDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace DM.Infrastructure.Data.CommandDb
{
    public class RepositoryCommandAll<TEntity> : IRepositoryCommandAll<TEntity> where TEntity : Entity,  IAggregateRoot
    {
        private readonly DoeMaisDbContextMySql _context;
        public RepositoryCommandAll(DoeMaisDbContextMySql context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().UpdateRange(entity);
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> filtro, params string[] includes) => await Query(true, includes).AnyAsync(filtro);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<TEntity>> FindBy(Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes)
        {
            return await Query(leitura, includes).Where(filtro).ToListAsync();
        }

        public async Task<IEnumerable<TResult>> FindBy<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes)
        {
            return await Query(leitura, includes).Where(filtro).Select(select).ToListAsync();
        }

        public async Task<TEntity> FindById(Guid id, bool leitura = false, params string[] includes)
        {
            return await Query(leitura, includes).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes)
        {
            return await Query(leitura, includes).FirstOrDefaultAsync(filtro);
        }

        public async Task<TResult> FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes)
        {
            return await Query(leitura, includes).Where(filtro).Select(select).FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> Query(bool leitura = false, params string[] includes)
        {
            var query = leitura
                 ? _context.Set<TEntity>().AsNoTracking()
                 : _context.Set<TEntity>();

            if (includes != null &&
                includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filtro, bool leitura = false, params string[] includes) => Query(leitura, includes).Where(filtro);
    }
}
