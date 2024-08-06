using Entities.Application;

namespace Domain.Services.Interfaces
{
    public interface IOrdemServicoDomainService
	{
		Task CadastrarOrdemServico(OrdemServicoPoco OrdemServico);
		Task CadastrarOrdemServico(OrdemServicoSimplesPoco OrdemServico);

		Task<OrdemServicoPoco> GetOrdemServico(int idOrdemServico);
		Task CancelarOrdemServico(int idOrdemServico);
		Task<List<OrdemServicoPoco>> GetAll();
		Task<List<OrdemServicoSimplesPoco>> GetAllSimples();

	}
}
