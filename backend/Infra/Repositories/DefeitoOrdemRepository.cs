using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    public class DefeitoOrdemRepository : GenericRepository<DefeitoOrdemPoco>, IDefeitoOrdemRepository
	{
		public DefeitoOrdemRepository(ApplicationContext context) : base(context)
		{
		}		
	}
}
