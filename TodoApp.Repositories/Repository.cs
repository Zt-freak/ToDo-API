using Microsoft.EntityFrameworkCore;
using System.Linq;
using TodoApp.Repositories.Interfaces;

namespace TodoApp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() => _dbSet = _dbContext.Set<TEntity>();

        public TEntity GetById(object id) => _dbSet.Find(id);

        public TEntity Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public void Remove(object id)
        {
            _dbContext.Remove(_dbSet.Find(id));
        }
    }
}
