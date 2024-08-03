using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    public class AtividadeOrdemRepository : GenericRepository<AtividadeOrdemPoco>, IAtividadeOrdemRepository
	{
		public AtividadeOrdemRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
