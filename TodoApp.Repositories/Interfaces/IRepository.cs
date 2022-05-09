using System.Linq;

namespace TodoApp.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void SaveChanges();
        void Remove(TEntity entity);
        void Remove(object id);
    }
}
