using AutoMapper;
using Application.Services.Interfaces;
using Entities.Application;
using DTOs.DTOs.OrdemServico;
using Domain.Services.Interfaces;

namespace Application.Services
{
	public class OrdemServicoService : IOrdemServicoService
	{
		private readonly IOrdemServicoDomainService _OrdemServicoDomainService;
		private readonly IMapper _mapper;

		public OrdemServicoService(IOrdemServicoDomainService OrdemServicoRepository, IMapper mapper)
		{
			_OrdemServicoDomainService = OrdemServicoRepository;
			_mapper = mapper;

		}

		public async Task<ResultService> CadastrarOrdemServico(CadastroOrdemDTO OrdemServicoDTO)
		{

			var OrdemServico = _mapper.Map<OrdemServicoPoco>(OrdemServicoDTO);

			await _OrdemServicoDomainService.CadastrarOrdemServico(OrdemServico);
			

			return ResultService.Ok(OrdemServico.IdOrdem);

		}

		public async Task<ResultService> CadastrarOrdemServico(CadastroOrdemSimplesDTO OrdemServicoDTO)
		{

			var OrdemServico = _mapper.Map<OrdemServicoSimplesPoco>(OrdemServicoDTO);

			await _OrdemServicoDomainService.CadastrarOrdemServico(OrdemServico);


			return ResultService.Ok(OrdemServico.IdOrdem);

		}

		public async Task<ResultService> CancelarOrdemServico(int idOrdemServico)
		{

			await _OrdemServicoDomainService.CancelarOrdemServico(idOrdemServico);
			return ResultService.Ok();

		}

		public async Task<ResultService> GetAll()
		{

			var OrdemServicos = await _OrdemServicoDomainService.GetAll();
			return ResultService.Ok(_mapper.Map<List<OrdemServicoDTO>>(OrdemServicos));

		}

		public async Task<ResultService> GetAllSimples()
		{

			var OrdemServicos = await _OrdemServicoDomainService.GetAllSimples();
			return ResultService.Ok(_mapper.Map<List<OrdemServicoSimplesDTO>>(OrdemServicos));

		}

		public async Task<ResultService> GetOrdemServico(int idOrdemServico)
		{

			var ordemServico = await _OrdemServicoDomainService.GetOrdemServico(idOrdemServico);

			return ResultService.Ok(_mapper.Map<OrdemServicoDTO>(ordemServico));

		}
	}
}
