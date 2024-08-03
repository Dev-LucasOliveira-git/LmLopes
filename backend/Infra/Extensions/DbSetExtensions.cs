using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;


/// <summary>
/// From: https://stackoverflow.com/questions/49593482/entity-framework-core-2-0-1-eager-loading-on-all-nested-related-entities
/// </summary>
public static class DbSetExtensions
{
	/* Usage : 
	 * 
	 * 
	 * 
			public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
			{
				var query = Context.Set<T>().Include(Context.GetIncludePaths(typeof(T));
				if (predicate != null)
					query = query.Where(predicate);

				return await query.ToListAsync();
			}
	 * 
	 * 
	 */


	public static IQueryable<T> Include<T>(this IQueryable<T> source, IEnumerable<string> navigationPropertyPaths) where T : class
	{
		return navigationPropertyPaths.Aggregate(source, (query, path) => query.Include(path));
	}

	// ******************************************************************
	/// <summary>
	/// Ensures that all navigation properties (up to a certain depth) are eagerly loaded when entities are resolved from this
	/// DbSet.
	/// </summary>
	/// <returns>The queryable representation of this DbSet</returns>
	public static IQueryable<TEntity> IncludeAll<TEntity>(
		this DbSet<TEntity> dbSet,
		int maxDepth = int.MaxValue) where TEntity : class
	{
		IQueryable<TEntity> result = dbSet;
		var context = dbSet.GetService<ICurrentDbContext>().Context;
		var includePaths = GetIncludePaths<TEntity>(context, maxDepth);

		foreach (var includePath in includePaths)
		{
			result = result.Include(includePath);
		}

		return result;
	}

	// ******************************************************************
	/// <remarks>
	/// Adapted from https://stackoverflow.com/a/49597502/1636276
	/// 
	/// EO : Original code only works for TPH not TPT
	/// 
	/// </remarks>
	public static IEnumerable<string> GetIncludePaths<T>(this DbContext context, int maxDepth = int.MaxValue)
	{
		if (maxDepth < 0)
			throw new ArgumentOutOfRangeException(nameof(maxDepth));

		var entityType = context.Model.FindEntityType(typeof(T));
		if (entityType == null)
		{
			throw new ArgumentException($"Unable to find the type: {typeof(T)} in the DbCOntext");
		}

		var includedNavigations = new HashSet<INavigation>();
		var stack = new Stack<IEnumerator<INavigation>>();

		while (true)
		{
			var entityNavigations = new List<INavigation>();
			if (stack.Count <= maxDepth)
			{
				foreach (INavigation navigation in entityType.GetNavigations())
				{
					if (includedNavigations.Add(navigation))
						entityNavigations.Add(navigation);
				}

				// EO: Here for TPT (Table Per Type), we also need to retreive navigations from 
				// derived class which have a corresponding <DBSet>
				foreach (var entityTypeDerived in entityType.GetDerivedTypes())
				{
					foreach (INavigation navigation in entityTypeDerived.GetNavigations())
					{
						if (includedNavigations.Add(navigation))
							entityNavigations.Add(navigation);
					}
				}
			}
			if (entityNavigations.Count == 0)
			{
				if (stack.Count > 0)
					yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
			}
			else
			{
				foreach (var navigation in entityNavigations)
				{
					var inverseNavigation = navigation.Inverse;
					if (inverseNavigation != null)
						includedNavigations.Add(inverseNavigation);
				}
				stack.Push(entityNavigations.GetEnumerator());
			}
			while (stack.Count > 0 && !stack.Peek().MoveNext())
				stack.Pop();
			if (stack.Count == 0) break;
			entityType = stack.Peek().Current.TargetEntityType;
		}
	}

	// ******************************************************************
}
