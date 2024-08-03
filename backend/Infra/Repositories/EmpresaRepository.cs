using Domain.Repositories;
using Entities.Application;
using Infra.Application;
using Infra.Repositories.Generics;

namespace Infra.Repositories
{
    public class EmpresaRepository : GenericRepository<EmpresaPoco>, IEmpresaRepository
	{
		public EmpresaRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
