using Hometask4_patterns.Data.Entities;
using System.Linq.Expressions;

namespace Hometask4_patterns.Repository.Abstractions
{
    public interface IRepository<TEntity, in TPrimaryKey> : IDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetAllList();

        Task<List<TEntity>> GetAllListIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        ValueTask<TEntity> Find(TPrimaryKey id);

        Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        Task<bool> All(Expression<Func<TEntity, bool>> predicate);

        Task<int> Count();

        Task<int> Count(Expression<Func<TEntity, bool>> predicate);

       Task Add(TEntity entity);

       Task Update(TEntity entity);

       Task Delete(TEntity entity);

       Task DeleteWhere(Expression<Func<TEntity, bool>> predicate);

       Task Commit(CancellationToken cancellationToken = default);
    }
}
