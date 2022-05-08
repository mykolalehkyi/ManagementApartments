using ManagementApartments.Data;
using ManagementApartments.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace ManagementApartments.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ManagementApartmentDbContext Context;
        public Repository(ManagementApartmentDbContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = Context.Set<TEntity>();
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        public IPagedList<TEntity> GetByPage(int page, int pageSize)
        {
            return Query().ToPagedList(page, pageSize);
        }
    }
}
