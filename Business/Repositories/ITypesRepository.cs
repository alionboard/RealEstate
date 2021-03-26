using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public interface ITypesRepository<T> where T : class, IType
    {
        IEnumerable<T> GetAllTTypes();
        T GetById(int Id);
        void Add(T Entity);
    }
}
