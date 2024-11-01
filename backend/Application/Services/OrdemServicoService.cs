using AutoMapper;
using Application.Services.Interfaces;
using Entities.Application;
using DTOs.DTOs.OrdemServico;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc;
using DTOs.DTOs.Ordem;
using System.IO;

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

		public async Task<ResultService> ProcessaAssinaturasOrdemServico(AssinaturaOrdemUploadDTO imagem)
		{
			if (imagem.ImgAssinaturaEngenheiro == null || imagem.ImgAssinaturaCliente == null || imagem.ImgAssinaturaCliente.Length == 0 || imagem.ImgAssinaturaEngenheiro.Length == 0)
			{
				throw new ArgumentNullException("Uma ou mais assinaturas são inválidas");
			}

			var imagensBytes = new List<byte[]>();

			// Converte cada imagem em byte[] e adiciona na lista

			using (var memoryStream = new MemoryStream())
			{
				await imagem.ImgAssinaturaCliente.CopyToAsync(memoryStream);
				imagensBytes.Add(memoryStream.ToArray());
			}

			using (var memoryStream = new MemoryStream())
			{
				await imagem.ImgAssinaturaEngenheiro.CopyToAsync(memoryStream);
				imagensBytes.Add(memoryStream.ToArray());
			}

			// Passa todas as imagens ao mesmo tempo
			await _ordemServicoDomainService.ProcessaAssinaturasOrdem(imagem.IdOrdem, imagensBytes);
			return ResultService.Ok();

		}

		public async Task<ResultService> GetAssinaturasOrdemServico(int idOrdemServico)
		{
			var assinaturasOrdem = await _ordemServicoDomainService.GetAssinaturasOrdem(idOrdemServico);

			// Retorna o arquivo de imagem como um FileStreamResult com o tipo correto

			var result = new AssinaturasOrdemDTO()
			{
				ImgAssinaturaEngenheiro = Convert.ToBase64String(assinaturasOrdem[0]),
				ImgAssinaturaCliente = Convert.ToBase64String(assinaturasOrdem[1])

			};

			return ResultService.Ok(result);

		}
	}
}
