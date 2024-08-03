
using Domain.Interfaces.Generics;

namespace Domain.Interfaces.UnitOfWork
{
	public interface IUnitOfWork<T> : IDisposable where T : class 
	{
		public void Save();		
	}
}