using DTOs.DTOs.Equipamento;

namespace Application.Services.Interfaces
{
	public interface IEquipamentoService
	{
		Task<ResultService> AtualizaEquipamento(EquipamentoDTO equipamento);
		Task<ResultService> GetEquipamento(int idEquipamento);
		Task<ResultService> CadastraEquipamento(CadastroEquipamentoDTO equipamento);
		Task<ResultService> GetAll();
		Task<ResultService> GetEquipamentoByDocument(string document);
	}
}
