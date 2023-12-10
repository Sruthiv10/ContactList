using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core.Interface
{
    public interface IGenericRepository<TEntity>
       where TEntity : class
    {
        TEntity Get(object id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity Create(TEntity entityToInsert);
        IEnumerable<TEntity> Create(IEnumerable<TEntity> entityToInsert);
        TEntity Modify(TEntity entityToUpdate);
        TEntity Delete(object id);
        TEntity Delete(TEntity entityToDelete);
        TEntity GetAsNoTracking(object id);
        IEnumerable<TEntity> GetByPage(int? page, int? rows, out int total, Expression<Func<TEntity, bool>> activeOnly = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
    }
}
