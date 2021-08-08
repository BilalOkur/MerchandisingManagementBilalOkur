using MerchandisingManagementCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MerchandisingManagementCore
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        protected DbContext BaseContext;

        protected RepositoryBase(DbContext dbContext)
        {
             this.BaseContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            BaseContext.Set<TEntity>().Add(entity);
            BaseContext.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            BaseContext.Set<TEntity>().Remove(entity);
            BaseContext.SaveChanges();
        }

        public void Dispose()
        {
            BaseContext.Dispose();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return BaseContext.Set<TEntity>().SingleOrDefault(predicate);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
             return BaseContext.Set<TEntity>().Where(filter).ToList();
        }

        public List<TEntity> GetAll()
        {
            return BaseContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
