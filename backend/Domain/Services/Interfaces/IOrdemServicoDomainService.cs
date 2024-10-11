using Entities.Application;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace Domain.Services.Interfaces
{
    public interface IOrdemServicoDomainService
	{
		Task CadastrarOrdemServico(OrdemServicoPoco OrdemServico);
		Task CadastrarOrdemServico(OrdemServicoSimplesPoco OrdemServico);

		Task<OrdemServicoSimplesPoco> GetOrdemServico(int idOrdemServico);
		Task CancelarOrdemServico(int idOrdemServico);
		Task<List<OrdemServicoPoco>> GetAll();
		Task<List<OrdemServicoSimplesPoco>> GetAllSimples();
		Task AtualizarOrdemServico(OrdemServicoSimplesPoco ordemServico);
		Task ProcessaAssinaturaOrdem(int idOrdem, byte[] imagem);

	}
}
