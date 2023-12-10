using AutoMapper;
using RFL.TechStack.Core.Common;
using RFL.TechStack.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core
{
    /// <summary>
    /// Generic service for domain serivice.
    /// </summary>
    /// <typeparam name="TEntity">entity.</typeparam>
    public class GenericService<TEntity> : IDisposable, IGenericService<TEntity>
           where TEntity : class
    {
        private readonly IGenericRepository<TEntity> repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericService{TEntity}"/> class.
        /// </summary>
        /// <param name="repository">repository instance.</param>
        /// <param name="mapper">mapper instance.</param>
        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Method for deleting entity details by id.
        /// </summary>
        /// <param name="entity">entity </param>
        /// <param name="userId">logged in user.</param>
        /// <returns>Responce.</returns>
        public virtual ExecuteResult<TEntity> Delete(TEntity entity)
        {
            ExecuteResult<TEntity> result = new ExecuteResult<TEntity>();
            var response = repository.Delete(entity);
            if (response != null)
            {
                result.Result = response;
                result.Success = response != null;
            }

            return result;
        }


        /// <summary>
        /// Method for getting details.
        /// </summary>
        /// <param name="id">entity identitfier.</param>
        /// <param name="isTrack">flag for entity track or not.</param>
        /// <returns>Response.</returns>
        public virtual ExecuteResult<TEntity> Get(Guid id, bool isTrack = true)
        {
            ExecuteResult<TEntity> result = new ExecuteResult<TEntity>();
            result.Result = isTrack ? repository.Get(id) : repository.GetAsNoTracking(id);
            result.Success = result != null;
            return result;
        }

        /// <summary>
        /// Get entity details based on filters.
        /// </summary>
        /// <param name="filter">filter condition.</param>
        /// <param name="orderBy">order by.</param>
        /// <param name="includeProperties">include child entities details.</param>
        /// <returns>Response.</returns>
        public virtual ExecuteResult<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var result = new ExecuteResult<TEntity>();
            var response = repository.Get(filter, orderBy, includeProperties);
            result.Success = response != null;
            if (result.Success)
            {
                result.Results = response;
            }

            return result;
        }

        /// <summary>
        /// Method for getting all entity details.
        /// </summary>
        /// <returns>Response.</returns>
        public virtual ExecuteResult<TEntity> GetAll()
        {
            ExecuteResult<TEntity> result = new ExecuteResult<TEntity>();
            result.Results = repository.GetAll();
            result.Success = result != null;
            return result;
        }
        
        
        /// <summary>
        /// Method for modify entity.
        /// </summary>
        /// <param name="entity">entity details.</param>
        /// <returns>Response.</returns>
        public virtual ExecuteResult<TEntity> Modify(TEntity entity)
        {
            ExecuteResult<TEntity> result = new ExecuteResult<TEntity>();
            result.Result = repository.Modify(entity);
            result.Success = result != null;
            return result;
        }

        /// <summary>
        /// Method for save details.
        /// </summary>
        /// <param name="entity">emtity details.</param>
        /// <returns>Response.</returns>
        public virtual ExecuteResult<TEntity> Save(TEntity entity)
        {
            ExecuteResult<TEntity> result = new ExecuteResult<TEntity>();
            entity = repository.Create(entity);
            result.Success = entity != null;
            result.Result = entity;
            return result;
        }

        /// <summary>
        /// Method for save details.
        /// </summary>
        /// <param name="entity">entity details.</param>
        /// <returns>Response.</returns>
        public virtual ExecuteResult<TEntity> Save(IEnumerable<TEntity> entities)
        {
            ExecuteResult<TEntity> result = new ExecuteResult<TEntity>();
            entities = repository.Create(entities);
            result.Success = entities != null & entities.Any();
            result.Results = entities;
            return result;
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
                    //repository = null;
                }
            }

            this.disposed = true;
        }
        #endregion IDisposible

        /// <summary>
        /// Generic method for setting properties.
        /// </summary>
        /// <param name="obj">object.</param>
        /// <param name="property">property.</param>
        /// <param name="value">value.</param>
        /// <returns>Response.</returns>
        private object TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
            }

            return obj;
        }

        /// <summary>
        /// Mehthod for getting entity details by page.
        /// </summary>
        /// <param name="page">page number.</param>
        /// <param name="rows">number of rows.</param>
        /// <param name="activeOnly">flag for filtering active items only.</param>
        /// <param name="filter">filter condition.</param>
        /// <param name="orderBy">order by.</param>
        /// <param name="includeProperties">includeProperties.</param>
        /// <returns>Response.</returns>
        public virtual ExecuteResult<TEntity> GetByPage(int? page, int? rows, Expression<Func<TEntity, bool>> activeOnly = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            int total = 0;
            ExecuteResult<TEntity> result = new ExecuteResult<TEntity>();
            IEnumerable<TEntity> procedure = Enumerable.Empty<TEntity>();
            procedure = repository.GetByPage(page, rows, out total, activeOnly, filter, orderBy, includeProperties);
            result.Success = procedure != null;
            if (result.Success)
            {
                result.Results = procedure;
                result.CurrentPage = page.GetValueOrDefault();
                result.PageSize = rows.GetValueOrDefault();
                result.TotalRecords = total;
            }

            return result;
        }
    }
}
