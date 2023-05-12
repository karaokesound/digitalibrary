using Library.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Services
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity :class
    {
        protected LibraryDbContext _context = null;

        protected DbSet<TEntity> _dbSet = null;

        public BaseRepository()
        {
            _context = new LibraryDbContext();
            _dbSet = _context.Set<TEntity>();
        }

        public BaseRepository(LibraryDbContext context)

        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        //public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        //{
        //    return _dbSet.FromSqlRaw(query, parameters).ToList();
        //}

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity existing = _dbSet.Find(id);
            _dbSet.Remove(existing);
        }

        public virtual void Delete(TEntity obj)
        {
            if (_context.Entry(obj).State == EntityState.Detached)
            {
                _dbSet.Attach(obj);
            }
            _dbSet.Remove(obj);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
