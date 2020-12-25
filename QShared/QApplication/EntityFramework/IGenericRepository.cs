namespace QApplication.EF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<ICollection<TEntity>> GetAll();

        Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> match);

        Task<TEntity> GetId(Expression<Func<TEntity, bool>> match);

        Task<bool> Create(TEntity entity);

        Task<int> CreateReturnId(TEntity entity);

        Task<bool> Create(List<TEntity> entity);

        Task<bool> Update(object key, TEntity entity);

        Task<bool> Update(TEntity entityExist, TEntity entity);

        Task<bool> Delete(object key);

        Task<bool> Delete(TEntity exist);

        Task<bool> QryDelete(Expression<Func<TEntity, bool>> match);

        Task<bool> DeleteAll(Expression<Func<TEntity, bool>> match);

        Task<TEntity> GetById(object key);

        Task<IEnumerable<TEntity>> GetAllExpressions(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] naProperties);
    }
}
