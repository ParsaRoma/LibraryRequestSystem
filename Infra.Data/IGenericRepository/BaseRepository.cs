using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.BaseEntities;
using Infra.Data.data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.IGenericRepository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _dataContext;
        public BaseRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<T> GetById(int id) 
        {
        return await _dataContext.Set<T>().FindAsync(id);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _dataContext.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            // await _dataContext.AddAsync(entity);
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            // In case AsNoTracking is used
            _dataContext.Entry(entity).State = EntityState.Modified;
            return _dataContext.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            return _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dataContext.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => _dataContext.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _dataContext.Set<T>().CountAsync(predicate);
        
        public IQueryable<T> Include(params Expression<Func<T, object>>[] Includes)
        {
        IQueryable<T> query = null;
        foreach (var include in Includes)
        {
            query = _dataContext.Set<T>().Include(include);
        }
        return query == null ? _dataContext.Set<T>() : query; 
        }

    }
}