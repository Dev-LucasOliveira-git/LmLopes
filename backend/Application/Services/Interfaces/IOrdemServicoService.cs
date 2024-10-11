using DTOs.DTOs.Ordem;
using DTOs.DTOs.OrdemServico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces
{
    public interface IOrdemServicoService
	{
		Task<ResultService> CadastrarOrdemServico(CadastroOrdemDTO OrdemServico);
		Task<ResultService> CadastrarOrdemServico(CadastroOrdemSimplesDTO OrdemServico);
		Task<ResultService> GetOrdemServico(int idOrdemServico);
		Task<ResultService> CancelarOrdemServico(int idOrdemServico);
		Task<ResultService> GetAll();
		Task<ResultService> GetAllSimples();
		Task <ResultService> AtualizarOrdemServico(OrdemServicoSimplesDTO ordemServicoDTO);
		Task <ResultService>ProcessaAssinaturaOrdemServico(AssinaturaOrdemUploadDTO imagem);
		Task<byte[]?> GetAssinaturaOrdemServico(int idOrdemServico);

	}
}
