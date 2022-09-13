using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.IGenericRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
    T Get(Guid id);
    IList<T> List();
    IList<T> ExpressionList(Expression<Func<T, bool>> expression);

    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    }

}