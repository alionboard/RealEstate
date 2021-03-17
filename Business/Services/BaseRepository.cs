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
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;
        public BaseRepository(ApplicationDbContext applicationDbContext)
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

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
