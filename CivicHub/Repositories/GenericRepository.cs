using CivicHub.Data;
using CivicHub.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(Context context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void CreateRange(List<T> entities)
        {
            _table.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public T FindById(Guid id)
        {
            return _table.Find(id);
        }

        public T FindByProperties(Object[] properties)
        {
            return _table.Find(properties);
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}
