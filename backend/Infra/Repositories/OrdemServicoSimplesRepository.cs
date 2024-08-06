using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    public class OrdemServicoSimplesRepository : GenericRepository<OrdemServicoSimplesPoco>, IOrdemServicoSimplesRepository
	{
		public OrdemServicoSimplesRepository(ApplicationContext context) : base(context)
		{
		}

	}
}
