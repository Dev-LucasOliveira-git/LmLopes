using DTOs.DTOs.OrdemServico;

namespace Application.Services.Interfaces
{
    public interface IOrdemServicoService
	{
		Task<ResultService> CadastrarOrdemServico(CadastroOrdemDTO OrdemServico);
		Task<ResultService> GetOrdemServico(int idOrdemServico);
		Task<ResultService> CancelarOrdemServico(int idOrdemServico);
		Task<ResultService> GetAll();
	}
}
