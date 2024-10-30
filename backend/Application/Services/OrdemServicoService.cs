using AutoMapper;
using Application.Services.Interfaces;
using Entities.Application;
using DTOs.DTOs.OrdemServico;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc;
using DTOs.DTOs.Ordem;

namespace Application.Services
{
	public class OrdemServicoService : IOrdemServicoService
	{
		private readonly IOrdemServicoDomainService _ordemServicoDomainService;
		private readonly IMapper _mapper;

		public OrdemServicoService(IOrdemServicoDomainService OrdemServicoRepository, IMapper mapper)
		{
			_ordemServicoDomainService = OrdemServicoRepository;
			_mapper = mapper;

		}

		public async Task<ResultService> CadastrarOrdemServico(CadastroOrdemDTO OrdemServicoDTO)
		{

			var OrdemServico = _mapper.Map<OrdemServicoPoco>(OrdemServicoDTO);

			await _ordemServicoDomainService.CadastrarOrdemServico(OrdemServico);
			

			return ResultService.Ok(OrdemServico.IdOrdem);

		}

		public async Task<ResultService> AtualizarOrdemServico(OrdemServicoSimplesDTO OrdemServicoDTO)
		{

			var OrdemServico = _mapper.Map<OrdemServicoSimplesPoco>(OrdemServicoDTO);

			await _ordemServicoDomainService.AtualizarOrdemServico(OrdemServico);


			return ResultService.Ok(OrdemServico.IdOrdem);

		}

		public async Task<ResultService> CadastrarOrdemServico(CadastroOrdemSimplesDTO OrdemServicoDTO)
		{

			var OrdemServico = _mapper.Map<OrdemServicoSimplesPoco>(OrdemServicoDTO);

			await _ordemServicoDomainService.CadastrarOrdemServico(OrdemServico);


			return ResultService.Ok(OrdemServico.IdOrdem);

		}

		public async Task<ResultService> CancelarOrdemServico(int idOrdemServico)
		{

			await _ordemServicoDomainService.CancelarOrdemServico(idOrdemServico);
			return ResultService.Ok();

		}

		public async Task<ResultService> GetAll()
		{

			var OrdemServicos = await _ordemServicoDomainService.GetAll();
			return ResultService.Ok(_mapper.Map<List<OrdemServicoDTO>>(OrdemServicos));

		}

		public async Task<ResultService> GetAllSimples()
		{

			var OrdemServicos = await _ordemServicoDomainService.GetAllSimples();
			return ResultService.Ok(_mapper.Map<List<OrdemServicoSimplesDTO>>(OrdemServicos));

		}

		public async Task<ResultService> GetOrdemServico(int idOrdemServico)
		{

			var ordemServico = await _ordemServicoDomainService.GetOrdemServico(idOrdemServico);

			return ResultService.Ok(_mapper.Map<OrdemServicoSimplesDTO>(ordemServico));

		}

		public async Task<ResultService> ProcessaAssinaturaClienteOrdemServico(AssinaturaOrdemUploadDTO imagem)
		{
			if (imagem.ImgForm == null || imagem.ImgForm.Length == 0)
			{
				throw new ArgumentNullException("Imagem não pode ser vazia");
			}

			using (var memoryStream = new MemoryStream())
			{
				await imagem.ImgForm.CopyToAsync(memoryStream);
				await _ordemServicoDomainService.ProcessaAssinaturaClienteOrdem(imagem.IdOrdem, memoryStream.ToArray());

			}
			return ResultService.Ok();

		}

		public async Task<ResultService> ProcessaAssinaturaEngenheiroOrdemServico(AssinaturaOrdemUploadDTO imagem)
		{
			if (imagem.ImgForm == null || imagem.ImgForm.Length == 0)
			{
				throw new ArgumentNullException("Imagem não pode ser vazia");
			}

			using (var memoryStream = new MemoryStream())
			{
				await imagem.ImgForm.CopyToAsync(memoryStream);
				await _ordemServicoDomainService.ProcessaAssinaturaClienteOrdem(imagem.IdOrdem, memoryStream.ToArray());

			}
			return ResultService.Ok();

		}

		public async Task<byte[]?> GetClienteAssinaturaOrdemServico(int idOrdemServico)
		{
			var ordemServicoPoco = await _ordemServicoDomainService.GetOrdemServico(idOrdemServico);

			
			// Retorna o arquivo de imagem como um FileStreamResult com o tipo correto
			return ordemServicoPoco.ImgAssinaturaCliente;

			//return ResultService.Ok();

		}

		public async Task<byte[]?> GetEngenheiroAssinaturaOrdemServico(int idOrdemServico)
		{
			var ordemServicoPoco = await _ordemServicoDomainService.GetOrdemServico(idOrdemServico);


			// Retorna o arquivo de imagem como um FileStreamResult com o tipo correto
			return ordemServicoPoco.ImgAssinaturaEngenheiro;

			//return ResultService.Ok();

		}
	}
}
