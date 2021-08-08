using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MerchandisingManagementCore.Interfaces
{
    public interface IRepositoryBase<T> where T : IEntity, new()
    {
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetList(Expression<Func<T, bool>> predicate = null);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
