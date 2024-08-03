using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Application;

namespace Domain.Services
{
	public class EquipamentoDomainService : IEquipamentoDomainService
	{
		private readonly IEquipamentoRepository _equipamentoRepository;
		
		public EquipamentoDomainService(IEquipamentoRepository equipamentoRepository)
		{
			_equipamentoRepository = equipamentoRepository;
			
		}
		public async Task AtualizaEquipamento(EquipamentoPoco equipamentoPoco)
		{


			var equipamentoPocoOld = await _equipamentoRepository.GetEntityById(equipamentoPoco.IdEquipamento);

			if (equipamentoPocoOld == null)
				throw new EntityNotFound("Equipamento não encontrado");


			equipamentoPocoOld.Nome = equipamentoPoco.Nome;
			equipamentoPocoOld.NumeroSerie = equipamentoPoco.NumeroSerie;
			equipamentoPocoOld.Tags = equipamentoPoco.Tags;

			await _equipamentoRepository.Update(equipamentoPocoOld);
		}

		public async Task CadastraEquipamento(EquipamentoPoco equipamentoPoco)
		{
			await _equipamentoRepository.Add(equipamentoPoco);
		}

		public async Task<List<EquipamentoPoco>> GetAll()
		{

			var equipamentos = await _equipamentoRepository.GetAll();
			return equipamentos;

		}

		public async Task<EquipamentoPoco> GetEquipamento(int idEquipamento)
		{

			var equipamento = await _equipamentoRepository.GetEntityById(idEquipamento);

			if(equipamento == null)
				throw new EntityNotFound("Equipamento não encontrado");


			return equipamento;

		}

		public async Task<EquipamentoPoco> GetEquipamentoByNumeroSerie(string numeroSerie)
		{
			var equipamento = await _equipamentoRepository.GetByExpression(x => x.NumeroSerie == numeroSerie);

			if(!equipamento.Any())
				throw new EntityNotFound("Equipamento não encontrado");


			return equipamento.First();
		}
	}
}
