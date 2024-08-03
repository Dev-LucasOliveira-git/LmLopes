using Application.Services.Interfaces;
using AutoMapper;
using Domain.Services.Interfaces;
using DTOs.DTOs.Engenheiro;
using Entities.Application;

namespace Application.Services
{
	public class EngenheiroService : IEngenheiroService
	{
		private readonly IEngenheiroDomainService _engenheiroDomainService;
		private readonly IMapper _mapper;

		public EngenheiroService(IEngenheiroDomainService engenheiroDomainService, IMapper mapper)
		{
			_engenheiroDomainService = engenheiroDomainService;
			_mapper = mapper;

		}
		public async Task<ResultService> AtualizaEngenheiro(EngenheiroDTO engenheiro)
		{
			var engenheiroPoco = _mapper.Map<EngenheiroPoco>(engenheiro);

			await _engenheiroDomainService.AtualizaEngenheiro(engenheiroPoco);

			return ResultService.Ok("Engenheiro atualizado com sucesso");

		}

		public async Task<ResultService> CadastraEngenheiro(CadastroEngenheiroDTO engenheiro)
		{

			var engenheiroPoco = _mapper.Map<EngenheiroPoco>(engenheiro);

			await _engenheiroDomainService.CadastraEngenheiro(engenheiroPoco);

			return ResultService.Ok();

		}

		public async Task<ResultService> GetAll()
		{

			var engenheiros = await _engenheiroDomainService.GetAll();
			return ResultService.Ok(_mapper.Map<List<EngenheiroDTO>>(engenheiros));

		}

		public async Task<ResultService> GetEngenheiro(int idEngenheiro)
		{

			var cupom = await _engenheiroDomainService.GetEngenheiro(idEngenheiro);
			return ResultService.Ok(_mapper.Map<EngenheiroDTO>(cupom));

		}

		public async Task<ResultService> GetEngenheiroByDocument(string document)
		{
			var engenheiroPoco = await _engenheiroDomainService.GetEngenheiroByDocument(document);

			return ResultService.Ok(_mapper.Map<EngenheiroDTO>(engenheiroPoco));


		}
	}
}
