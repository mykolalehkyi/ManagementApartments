using System;
using System.Linq;
using System.Linq.Expressions;
using X.PagedList;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IPagedList<TEntity> GetByPage(int page, int pageSize);
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
    }
}