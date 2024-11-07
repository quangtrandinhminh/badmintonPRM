using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure;
using System.Linq.Expressions;
using Repository.Extensions;
using System.Collections.Generic;

namespace Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public IQueryable<T?> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        // get all with paging, return paginated queryable and all page count
        public async Task<PaginatedList<T>> GetAllPaginatedQueryable(int page, int pageSize,
            Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _dbSet.AsNoTracking();
            includeProperties = includeProperties?.Distinct().ToArray();
            if (includeProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = includeProperties;
                foreach (Expression<Func<T, object>> navigationPropertyPath in array)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            var paginatedList = await PaginatedList<T>.CreateAsync(queryable, page, pageSize);
            return paginatedList;
        }

        public IQueryable<T> GetAllWithCondition(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _dbSet.AsNoTracking();
            includeProperties = includeProperties?.Distinct().ToArray();
            if (includeProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = includeProperties;
                foreach (Expression<Func<T, object>> navigationPropertyPath in array)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            return predicate == null ? queryable : queryable.Where(predicate);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbSet.AsQueryable();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            TryAttach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            TryAttach(entity);
            _dbSet.Remove(entity);
        }

        public void TryAttach(T entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
            }
            catch
            {
            }
        }

        public void TryAttachRange(ICollection<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    if (_context.Entry(entity).State != EntityState.Detached)
                    {
                        entities.Remove(entity);
                    }
                }
                _dbSet.AttachRange(entities);
            }
            catch
            {
            }
        }
    }
}
