using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;
using Domain.Interfaces.Generics;
using Infra.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Generics
{
	public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
	{
		private readonly ApplicationContext _context;
		public GenericRepository(ApplicationContext context)
		{
			_context = context;
		}
		public async Task Add(T Obj)
		{
			await _context.Set<T>().AddAsync(Obj);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(T Obj)
		{
			_context.Set<T>().Remove(Obj);
			await _context.SaveChangesAsync();
		}

		public async Task<List<T>> GetAll(params string[] propertySelectors)
		{
			IQueryable<T> queryable = _context.Set<T>().AsNoTracking().AsQueryable();
			if (propertySelectors.Count() > 0)
			{
				foreach (var navigationPropertyPath in propertySelectors)
				{
					queryable = queryable.Include(navigationPropertyPath);
				}
			}

			return await queryable.ToListAsync();
		}

		public async Task<T?> GetEntityById(int Id)
		{
			var entity = _context.Set<T>().Find(Id);

			if (entity != null)
				_context.Entry(entity).State = EntityState.Detached;
			
			return entity;
		}

		public async Task Update(T Obj)
		{
			_context.Set<T>().Update(Obj);
			await _context.SaveChangesAsync();
		}

		public async Task<List<T>> GetByExpression(Expression<Func<T, bool>> expression, params string[] propertySelectors)
		{
			IQueryable<T> queryable = _context.Set<T>().AsNoTracking().AsQueryable();
			if (propertySelectors.Count() > 0)
			{
				foreach (var navigationPropertyPath in propertySelectors)
				{
					queryable = queryable.Include(navigationPropertyPath);
				}
			}

			return await queryable.Where(expression).ToListAsync();

		}

		public async Task DeleteRangeAsync(Expression<Func<T, bool>> predicate)
		{
			var entities = await _context.Set<T>().Where(predicate).ToListAsync();
			_context.Set<T>().RemoveRange(entities);
		}

		public async Task ExecuteInTransactionAsync(Func<Task> action)
		{
			using var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				await action();
				await _context.SaveChangesAsync();
				await transaction.CommitAsync();
			}
			catch
			{
				await transaction.RollbackAsync();
				throw;
			}
		}


		#region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
		// Flag: Has Dispose already been called?
		bool disposed = false;
		// Instantiate a SafeHandle instance.
		//SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



		// Public implementation of Dispose pattern callable by consumers.
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		// Protected implementation of Dispose pattern.
		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				//handle.Dispose();
				// Free any other managed objects here.
				//
			}

			disposed = true;
		}
		#endregion


	}
}