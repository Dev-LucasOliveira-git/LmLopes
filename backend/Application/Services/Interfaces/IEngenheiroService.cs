using DTOs.DTOs.Engenheiro;

namespace Application.Services.Interfaces
{
	public interface IEngenheiroService
	{

		Task<ResultService> AtualizaEngenheiro(EngenheiroDTO engenheiro);
		Task<ResultService> GetEngenheiro(int idEngenheiro);
		Task<ResultService> CadastraEngenheiro(CadastroEngenheiroDTO engenheiro);
		Task<ResultService> GetAll();
		Task<ResultService> GetEngenheiroByDocument(string document);
	}
}
