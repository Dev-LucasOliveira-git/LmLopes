using Domain.Repositories;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
	public class UsuarioRepository : GenericRepository<UsuarioPoco>, IUsuarioRepository
	{
		public UsuarioRepository(ApplicationContext context) : base(context)
		{
		}	

	}
}
