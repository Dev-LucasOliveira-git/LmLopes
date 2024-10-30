﻿using DTOs.DTOs.Ordem;
using DTOs.DTOs.OrdemServico;

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
		Task <ResultService>ProcessaAssinaturaClienteOrdemServico(AssinaturaOrdemUploadDTO imagem);
		Task<ResultService> ProcessaAssinaturaEngenheiroOrdemServico(AssinaturaOrdemUploadDTO imagem);
		Task<byte[]?> GetClienteAssinaturaOrdemServico(int idOrdemServico);
		Task<byte[]?> GetEngenheiroAssinaturaOrdemServico(int idOrdemServico);


	}
}
