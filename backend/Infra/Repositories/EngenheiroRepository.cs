using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
	public class EngenheiroRepository : GenericRepository<EngenheiroPoco>, IEngenheiroRepository
	{
		public EngenheiroRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
