using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
	public class EquipamentoRepository : GenericRepository<EquipamentoPoco>, IEquipamentoRepository
	{
		public EquipamentoRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
