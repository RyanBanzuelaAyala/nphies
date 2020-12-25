namespace QApplication.EF
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class GenericService<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _dbContext;

        internal DbSet<TEntity> dbSet;

        public GenericService(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this.dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAll(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<TEntity> GetId(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(match);
        }

        public async Task<bool> Create(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<int> CreateReturnId(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                var idProperty = entity.GetType().GetProperty("SystemId").GetValue(entity, null);

                return (int)idProperty;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public async Task<bool> Create(List<TEntity> entity)
        {
            try
            {
                _dbContext.Set<List<TEntity>>().AddRange(entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Update(object key, TEntity entity)
        {
            TEntity exist = await _dbContext.Set<TEntity>().FindAsync(key);

            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(TEntity entityExist, TEntity entity)
        {
            _dbContext.Entry(entityExist).CurrentValues.SetValues(entity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(object key)
        {
            TEntity exist = await _dbContext.Set<TEntity>().FindAsync(key);

            if (exist != null)
            {
                _dbContext.Set<TEntity>().Remove(exist);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(TEntity exist)
        {

            _dbContext.Set<TEntity>().Remove(exist);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> QryDelete(Expression<Func<TEntity, bool>> match)
        {
            TEntity exist = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(match);

            if (exist != null)
            {
                _dbContext.Set<TEntity>().Remove(exist);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAll(Expression<Func<TEntity, bool>> match)
        {
            var exist = await _dbContext.Set<TEntity>().Where(match).ToListAsync();

            if (exist.Count != 0)
            {
                _dbContext.Set<TEntity>().RemoveRange(exist);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TEntity> GetById(object key)
        {
            return await _dbContext.Set<TEntity>().FindAsync(key);
        }

        public async Task<IEnumerable<TEntity>> GetAllExpressions(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] naProperties)
        {
            IQueryable<TEntity> dbQuery = dbSet;

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            foreach (Expression<Func<TEntity, object>> nProperty in naProperties)
                dbQuery = dbQuery.Include<TEntity, object>(nProperty);

            if (orderBy != null)
            {
                dbQuery = orderBy(dbQuery);
            }

            return await dbQuery.ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}
