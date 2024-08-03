using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    internal class MaterialUtilizadoRepository : GenericRepository<MaterialUtilizadoPoco>, IMaterialUtilizadoRepository
	{
		public MaterialUtilizadoRepository(ApplicationContext context) : base(context)
		{
		}		
	}
}
