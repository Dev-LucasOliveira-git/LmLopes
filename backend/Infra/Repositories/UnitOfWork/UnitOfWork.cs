using Domain.Interfaces.Generics;
using Domain.Interfaces.UnitOfWork;
using Infra.Application;
using Infra.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.UnitOfWork
{
	public class UnitOfWork<T> : IUnitOfWork<T> where T : class
	{
		private readonly ApplicationContext _context;

		private GenericRepository<T> genericRepository;

		public GenericRepository<T> GenericRepository
		{
			get
			{

				if (this.genericRepository == null)
				{
					this.genericRepository = new GenericRepository<T>(_context);
				}
				return genericRepository;
			}
		}		

		public void Save()
		{
			_context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}