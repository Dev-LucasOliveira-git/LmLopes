using DTOs.DTOs.Empresa;

namespace Application.Services.Interfaces
{
    public interface IEmpresaService
	{
		Task<ResultService> AtualizaEmpresa(EmpresaDTO empresa);
		Task<ResultService> GetEmpresa();

	}
}
