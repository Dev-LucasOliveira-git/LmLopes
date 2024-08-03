using Domain.Interfaces;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    public class ClienteRepository : GenericRepository<ClientePoco>, IClienteRepository
	{
		public ClienteRepository(ApplicationContext context) : base(context)
		{
		}
		
	}
}
