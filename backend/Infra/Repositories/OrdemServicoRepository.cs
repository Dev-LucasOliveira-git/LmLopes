using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    public class OrdemServicoRepository : GenericRepository<OrdemServicoPoco>, IOrdemServicoRepository
	{
		public OrdemServicoRepository(ApplicationContext context) : base(context)
		{
		}

	}
}
