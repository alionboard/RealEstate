using Business.Repositories;
using Data.Context;
using Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class TypeBaseRepository<T> : ITypesRepository<T> where T : class, IType
    {
        private readonly RealEstateDbContext _context;
        private DbSet<T> _entities;

        public TypeBaseRepository(RealEstateDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Add(T Entity)
        {
            _entities.Add(Entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAllTTypes()
        {
            return _entities.ToList();
        }

        public virtual T GetById(int id)
        {
            return _entities.Find(id);
        }
    }
}
