using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> where T : class
    {
        private readonly Models.CoffeeShopManagementContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase()
        {
            _context= new Models.CoffeeShopManagementContext();
            _dbSet= _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;

            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public T Find(Guid id)
        {
            return _dbSet.Find(id);
        }
    }
}
