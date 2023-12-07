using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
