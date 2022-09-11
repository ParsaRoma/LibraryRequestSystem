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
        private readonly ApplicationDbContext _dataContext;
        public BaseRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
       
        }
        public T Get(Guid id)
        {   
            return _dataContext.Set<T>().Find(id);
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] Includes)
        {
        IQueryable<T> query = null;
        foreach (var include in Includes)
        {
            query = _dataContext.Set<T>().Include(include);
        }
        return query == null ? _dataContext.Set<T>() : query; 
        }

        public void Insert(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            
        }

        public IList<T> List()
        {
            return _dataContext.Set<T>().ToList();
        }

        public IList<T> List(Expression<Func<T, bool>> expression)
        {
            return _dataContext.Set<T>().Where(expression).ToList();
        }

        public void Update(T entity)
        {
            _dataContext.Entry<T>(entity).State = EntityState.Modified; 
            
        }
    }
}