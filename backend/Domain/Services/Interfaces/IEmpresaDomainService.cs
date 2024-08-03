using Entities.Application;

namespace Domain.Services.Interfaces
{
	public interface IEmpresaDomainService
	{
		Task AtualizaEmpresa(EmpresaPoco empresa);
		Task<EmpresaPoco> GetEmpresa();

	}
}
