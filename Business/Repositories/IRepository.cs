using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);

    }
}
