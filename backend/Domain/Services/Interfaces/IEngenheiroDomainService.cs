using Entities.Application;

namespace Domain.Services.Interfaces
{
	public interface IEngenheiroDomainService
	{
		Task AtualizaEngenheiro(EngenheiroPoco engenheiro);
		Task<EngenheiroPoco> GetEngenheiro(int idEngenheiro);
		Task CadastraEngenheiro(EngenheiroPoco engenheiro);
		Task<List<EngenheiroPoco>> GetAll();
		Task<EngenheiroPoco> GetEngenheiroByDocument(string document);
	}
}
