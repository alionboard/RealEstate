using Business.Repositories;
using Data.Context;
using Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Services
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly RealEstateDbContext _context;
        private DbSet<T> _entities;
        public BaseRepository(RealEstateDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _entities = applicationDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return _entities.AsEnumerable();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
