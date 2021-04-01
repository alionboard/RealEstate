using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Repositories
{
    public interface ITypesRepository<T> where T : class, IType
    {
        IEnumerable<T> GetAllTTypes();
        void AddAllTTypes(List<T> entities);
        void DeleteAllTTypes(Expression<Func<T, bool>> filter);
        T GetById(int Id);
        void Add(T Entity);
    }
}
