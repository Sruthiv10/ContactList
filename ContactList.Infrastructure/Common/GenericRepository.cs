using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Infrastructure.Common
{
    /// <summary>
    /// GenericRepository    ///. </summary>
    /// <typeparam name="TEntity">Response.</typeparam>
    public class GenericRepository<TEntity> : IDisposable
          where TEntity : class

        // where TContext : DbContext, new()
    {
        private DbContext context;
        private DbSet<TEntity> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Method for getting details.
        /// </summary>
        /// <param name="id">entity identitfier.</param>
        /// <returns>TEntity.</returns>
        public virtual TEntity Get(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <returns>TEntity.</returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        /// <summary>
        /// Get entity details based on filters.
        /// </summary>
        /// <param name="filter">filter condition.</param>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">include child entities details.</param>
        /// <returns>TEntity.</returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!query.Any())
            {
                return new List<TEntity>();
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty).AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Save information.
        /// </summary>
        /// <param name="entityToInsert">DTO class.</param>
        /// <returns>TEntity.</returns>
        public virtual TEntity Create(TEntity entityToInsert)
        {
            TEntity entity = dbSet.Add(entityToInsert).Entity;
            context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Save multiple information.
        /// </summary>
        /// <param name="entityToInsert">DTO class.</param>
        /// <returns>TEntity.</returns>
        public virtual IEnumerable<TEntity> Create(IEnumerable<TEntity> entityToInsert)
        {
            dbSet.AddRange(entityToInsert);
            context.SaveChanges();
            return entityToInsert;
        }

        ///// <summary>
        ///// Save information.
        ///// </summary>
        ///// <param name="listToInsert">DTO class.</param>
        ///// <returns>TEntity.</returns>
        //public virtual IEnumerable<TEntity> Create(IList<TEntity> listToInsert)
        //{
        //    using (var transaction = new System.Transactions.TransactionScope())
        //    {
        //        var bulkConfig = new BulkConfig { SetOutputIdentity = true };
        //        context.BulkInsert(listToInsert, bulkConfig);
        //        transaction.Complete();
        //    }

        //    return listToInsert;
        //}

        /// <summary>
        /// Modify the details.
        /// </summary>
        /// <param name="entityToUpdate">dto class.</param>
        /// <returns>TEntity.</returns>
        public virtual TEntity Modify(TEntity entityToUpdate)
        {
            context.ChangeTracker.Clear();
            TEntity entity = dbSet.Attach(entityToUpdate).Entity;
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        ///// <summary>
        ///// Save information.
        ///// </summary>
        ///// <param name="listToInsert">DTO class.</param>
        ///// <returns>TEntity.</returns>
        //public virtual IEnumerable<TEntity> Modify(IList<TEntity> listToInsert)
        //{
        //    using (var transaction = context.Database.BeginTransaction())
        //    {
        //        var bulkConfig = new BulkConfig { SetOutputIdentity = true };
        //        context.BulkUpdate(listToInsert, bulkConfig);
        //        transaction.Commit();
        //    }

        //    return listToInsert;
        //}

        ///// <summary>
        ///// Delete Bulk information.
        ///// </summary>
        ///// <param name="listToDelete">DTO class.</param>
        ///// <returns>TEntity.</returns>
        //public virtual IEnumerable<TEntity> Delete(IList<TEntity> listToDelete)
        //{
        //    using (var transaction = context.Database.BeginTransaction())
        //    {
        //        context.BulkDelete(listToDelete);
        //        transaction.Commit();
        //    }

        //    return listToDelete;
        //}

        /// <summary>
        /// Method for deleting entity details by id.
        /// </summary>
        /// <param name="id">entity id.</param>
        /// <returns>Responce.</returns>
        public virtual TEntity Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }

        /// <summary>
        /// Delete details by entityToDelete.
        /// </summary>
        /// <param name="entityToDelete">TEntity.</param>
        /// <returns>Entity.</returns>
        public virtual TEntity Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            TEntity entity = dbSet.Remove(entityToDelete).Entity;
            context.SaveChanges();
            return entity;
        }

        public virtual IEnumerable<TEntity> GetByPage(int? page, int? rows, out int total, Expression<Func<TEntity, bool>> activeOnly = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (activeOnly != null && filter != null)
            {
                query = query.Where(Helper.AndAlso(activeOnly, filter));
            }
            else if (filter != null)
            {
                query = query.Where(filter);
            }
            else if (activeOnly != null)
            {
                query = query.Where(activeOnly);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty).AsNoTracking();
                }
            }

            total = query.Count();

            //if (orderBy != null)
            //{
            //    total = orderBy(query).Count();
            //}
            //else
            //{
            //    total = query.Count();
            //}
            if (orderBy != null)
            {
                if (filter == null)
                {
                    return orderBy(query).ToList().Skip((page - 1 ?? 0) * (rows ?? 3)).Take(rows ?? 3);
                }
                else
                {
                    return orderBy(query).ToList();
                }
            }
            else
            {
                if (filter == null)
                {
                    return query.ToList().Skip((page - 1 ?? 0) * (rows ?? 3)).Take(rows ?? 3);
                }
                else
                {
                    return query.ToList();
                }
            }

            //return query.ToList();

            // return query.Skip((page - 1 ?? 0) * (rows ?? 3)).Take(rows ?? 3).ToList();
        }

        /// <summary>
        /// Method for get details by page.
        /// </summary>
        /// <param name="total">total.</param>
        /// <param name="activeOnly">activeOnly.</param>
        /// <param name="filter">filter.</param>
        /// <param name="includeProperties">includeProperties</param>
        /// <returns>TEntity.</returns>
        public virtual IEnumerable<TEntity> GetAll(out int total, Expression<Func<TEntity, bool>> activeOnly = null, Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (activeOnly != null && filter != null)
            {
                query = query.Where(Helper.AndAlso(activeOnly, filter));
            }
            else if (filter != null)
            {
                query = query.Where(filter);
            }
            else if (activeOnly != null)
            {
                query = query.Where(activeOnly);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty).AsNoTracking();
                }
            }

            total = query.Count();
            return query.ToList();
        }

        #region  IDisposible
        private bool disposed = false;

        /// <summary>
        /// Dispose instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method/.
        /// </summary>
        /// <param name="disposing">flag for dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }
        #endregion IDisposible
    }
}
