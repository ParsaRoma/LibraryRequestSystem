using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.BaseEntities;
using Infra.Data.IGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Extentions
{
    public static class IncludeExtension
    {
           public static IQueryable<TEntity> Include<TEntity>(this DbSet<TEntity> dbSet,
           params Expression<Func<TEntity, object>>[] includes)
           where TEntity : class
           
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }
            return query == null ? dbSet : query;

        }

        //  public static IQueryable<T> INclude<T>(this BaseRepository<T> baseRepository,
        //    params Expression<Func<T, object>>[] includes)
        //    where T : BaseEntity
           
        // {
        //     IQueryable<T> query = null;
        //     foreach (var include in includes)
        //     {
        //         query = baseRepository.INclude(include);
        //     }
        //     return query == null ? baseRepository : query;

        // }

    }
}