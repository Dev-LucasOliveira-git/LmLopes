using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    public class EstadoRepository : GenericRepository<EstadoPoco>, IEstadoRepository
	{
		public EstadoRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
