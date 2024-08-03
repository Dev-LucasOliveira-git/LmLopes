using Entities.Application;

namespace Domain.Services.Interfaces
{
	public interface IClienteDomainService
	{
		Task AtualizaCliente(ClientePoco cliente);
		Task<ClientePoco> GetCliente(int idCliente);
		Task CadastraCliente(ClientePoco cliente);
		Task<List<ClientePoco>> GetAll();
		Task<ClientePoco> GetClienteByDocument(string document);

	}
}
