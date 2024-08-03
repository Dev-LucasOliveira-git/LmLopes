using AutoMapper;
using Application.Services.Interfaces;
using Entities.Application;
using DTOs.DTOs.Cliente;
using Domain.Services.Interfaces;

namespace Application.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteDomainService _clienteDomainService;
		private readonly IMapper _mapper;

		public ClienteService(IClienteDomainService clienteDomainService, IMapper mapper)
		{
			_clienteDomainService = clienteDomainService;
			_mapper = mapper;

		}
		public async Task<ResultService> AtualizaCliente(ClienteDTO cliente)
		{
			var clientePoco = _mapper.Map<ClientePoco>(cliente);

			await _clienteDomainService.AtualizaCliente(clientePoco);

			return ResultService.Ok("Cliente atualizado com sucesso");

		}

		public async Task<ResultService> CadastraCliente(CadastroClienteDTO cliente)
		{

			var clientePoco = _mapper.Map<ClientePoco>(cliente);

			await _clienteDomainService.CadastraCliente(clientePoco);

			return ResultService.Ok();

		}

		public async Task<ResultService> GetAll()
		{

			var clientes = await _clienteDomainService.GetAll();
			return ResultService.Ok(_mapper.Map<List<ClienteDTO>>(clientes));

		}

		public async Task<ResultService> GetCliente(int idCliente)
		{

			var cupom = await _clienteDomainService.GetCliente(idCliente);
			return ResultService.Ok(_mapper.Map<ClienteDTO>(cupom));

		}

		public async Task<ResultService> GetClienteByDocument(string document)
		{
			var clientePoco = await _clienteDomainService.GetClienteByDocument(document);

			return ResultService.Ok(_mapper.Map<ClienteDTO>(clientePoco));


		}
	}
}
