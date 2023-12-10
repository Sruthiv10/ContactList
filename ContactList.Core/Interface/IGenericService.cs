using RFL.TechStack.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core.Interface
{
    public interface IGenericService<T>
    {
        ExecuteResult<T> Get(Guid id, bool isTrack = true);
        ExecuteResult<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        ExecuteResult<T> GetAll();
        ExecuteResult<T> Save(T entity);
        ExecuteResult<T> Save(IEnumerable<T> entity);
        ExecuteResult<T> Modify(T entity);
        ExecuteResult<T> Delete(T entity);
        ExecuteResult<T> GetByPage(int? page, int? rows, Expression<Func<T, bool>> activeOnly = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
    }
}
