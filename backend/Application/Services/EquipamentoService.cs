using Application.Services.Interfaces;
using AutoMapper;
using Domain.Services.Interfaces;
using DTOs.DTOs.Equipamento;
using Entities.Application;

namespace Application.Services
{
	public class EquipamentoService : IEquipamentoService
	{
		private readonly IEquipamentoDomainService _equipamentoDomainService;
		private readonly IMapper _mapper;

		public EquipamentoService(IEquipamentoDomainService equipamentoDomainService, IMapper mapper)
		{
			_equipamentoDomainService = equipamentoDomainService;
			_mapper = mapper;

		}
		public async Task<ResultService> AtualizaEquipamento(EquipamentoDTO equipamento)
		{
			var equipamentoPoco = _mapper.Map<EquipamentoPoco>(equipamento);

			await _equipamentoDomainService.AtualizaEquipamento(equipamentoPoco);

			return ResultService.Ok("Equipamento atualizado com sucesso");

		}

		public async Task<ResultService> CadastraEquipamento(CadastroEquipamentoDTO equipamento)
		{

			var equipamentoPoco = _mapper.Map<EquipamentoPoco>(equipamento);

			await _equipamentoDomainService.CadastraEquipamento(equipamentoPoco);

			return ResultService.Ok();

		}

		public async Task<ResultService> GetAll()
		{

			var equipamentos = await _equipamentoDomainService.GetAll();
			return ResultService.Ok(_mapper.Map<List<EquipamentoDTO>>(equipamentos));

		}

		public async Task<ResultService> GetEquipamento(int idEquipamento)
		{

			var cupom = await _equipamentoDomainService.GetEquipamento(idEquipamento);
			return ResultService.Ok(_mapper.Map<EquipamentoDTO>(cupom));

		}

		public async Task<ResultService> GetEquipamentoByDocument(string document)
		{
			var equipamentoPoco = await _equipamentoDomainService.GetEquipamentoByNumeroSerie(document);

			return ResultService.Ok(_mapper.Map<EquipamentoDTO>(equipamentoPoco));


		}
	}
}
