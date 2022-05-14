using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using X.PagedList;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        IPagedList<TEntity> GetByPage(int page, int pageSize);
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}