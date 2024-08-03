using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    internal class CidadeRepository : GenericRepository<CidadePoco>, ICidadeRepository
	{
		public CidadeRepository(ApplicationContext context) : base(context)
		{
		}
		
	}
}
