using System;
using System.Linq.Expressions;
using Domain.Common;

namespace Repository.Repositories.Interfaces
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task CreateAsync(T entity);
		Task EditAsync(T entity);
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllWithExpressions(Expression<Func<T, bool>> predicate);
        Task <T> GetWithExpressions(Expression<Func<T, bool>> predicate);
		Task DeleteAsync(int id);

    }
}

