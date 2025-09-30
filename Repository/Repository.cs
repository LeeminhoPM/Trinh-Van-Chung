using ChungTrinhj.Models;
using ChungTrinhj.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChungTrinhj.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly ChungTrinhjDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ChungTrinhjDbContext db)
        {
            this._db = db;
            this.dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
