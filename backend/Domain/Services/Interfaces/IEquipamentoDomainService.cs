using Entities.Application;

namespace Domain.Services.Interfaces
{
	public interface IEquipamentoDomainService
	{
		Task AtualizaEquipamento(EquipamentoPoco equipamento);
		Task<EquipamentoPoco> GetEquipamento(int idEquipamento);
		Task CadastraEquipamento(EquipamentoPoco equipamento);
		Task<List<EquipamentoPoco>> GetAll();
		Task<EquipamentoPoco> GetEquipamentoByNumeroSerie(string document);
	}
}
