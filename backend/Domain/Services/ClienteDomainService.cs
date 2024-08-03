using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Application;

namespace Domain.Services
{
	public class ClienteDomainService : IClienteDomainService
	{
		private readonly IClienteRepository _clienteRepository;
		
		private readonly ITokenDomainService _tokenService;

		public ClienteDomainService(IClienteRepository clienteRepository, ITokenDomainService tokenService)
		{
			_clienteRepository = clienteRepository;
			
			_tokenService = tokenService;

		}
		public async Task AtualizaCliente(ClientePoco clientePoco)
		{


			var clientePocoOld = await _clienteRepository.GetEntityById(clientePoco.IdCliente);

			if (clientePocoOld == null)
				throw new EntityNotFound("Cliente não encontrado");


			clientePocoOld.Nome = clientePoco.Nome;
			clientePocoOld.Email = clientePoco.Email;
			clientePocoOld.CpfCnpj = clientePoco.CpfCnpj;
			clientePocoOld.Endereco = clientePoco.Endereco;
			clientePocoOld.Bairro = clientePoco.Bairro;
			clientePocoOld.Numero = clientePoco.Numero;
			clientePocoOld.CEP = clientePoco.CEP;
			clientePocoOld.DataHoraUltimaAlteracao = DateTime.Now;
			clientePocoOld.IdUsuarioUltimaAlteracao = await _tokenService.GetIdUsuario();


			await _clienteRepository.Update(clientePocoOld);
		}

		public async Task CadastraCliente(ClientePoco clientePoco)
		{

			clientePoco.IdUsuarioCadastro = clientePoco.IdUsuarioUltimaAlteracao = await _tokenService.GetIdUsuario();

			await _clienteRepository.Add(clientePoco);
		}

		public async Task<List<ClientePoco>> GetAll()
		{

			var clientes = await _clienteRepository.GetAll();
			return clientes;

		}

		public async Task<ClientePoco> GetCliente(int idCliente)
		{

			var cliente = await _clienteRepository.GetEntityById(idCliente);

			if(cliente == null)
				throw new EntityNotFound("Cliente não encontrado");


			return cliente;

		}

		public async Task<ClientePoco> GetClienteByDocument(string document)
		{
			var cliente = await _clienteRepository.GetByExpression(x => x.CpfCnpj == document);

			if(!cliente.Any())
				throw new EntityNotFound("Cliente não encontrado");


			return cliente.First();
		}
	}
}
