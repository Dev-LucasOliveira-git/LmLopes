using System.Linq.Expressions;


namespace Domain.Interfaces.Generics
{
	public interface IGenericRepository<T> where T : class
	{
		Task Add(T Obj);
		Task Update(T Obj);
		Task Delete(T Obj);
		Task<T?> GetEntityById(int Id);
		Task<List<T>> GetAll(params string[] propertySelectors);
		Task<List<T>> GetByExpression(Expression<Func<T, bool>> expression, params string[] propertySelectors);
		Task DeleteRangeAsync(Expression<Func<T, bool>> predicate);
		Task ExecuteInTransactionAsync(Func<Task> action);
	}
}
