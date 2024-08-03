using DTOs.DTOs.Cliente;

namespace Application.Services.Interfaces
{
    public interface IClienteService
	{
		Task<ResultService> AtualizaCliente(ClienteDTO cliente);
		Task<ResultService> GetCliente(int idCliente);
		Task<ResultService> CadastraCliente(CadastroClienteDTO cliente);
		Task<ResultService> GetAll();
		Task<ResultService> GetClienteByDocument(string document);
	}
}
