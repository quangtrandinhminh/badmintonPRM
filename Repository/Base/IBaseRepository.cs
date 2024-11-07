using System.Linq.Expressions;
using Repository.Extensions;

namespace Repository.Base;

public interface IBaseRepository<T> where T : class, new()
{
    Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T?> GetAll();
    Task<PaginatedList<T>> GetAllPaginatedQueryable(int page, int pageSize, Expression<Func<T, bool>> predicate = null,
        params Expression<Func<T, object>>[] includeProperties);
    IQueryable<T> GetAllWithCondition(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    void TryAttachRange (ICollection<T> entities);
}
