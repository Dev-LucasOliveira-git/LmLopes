using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using DTOs.DTOs.Cliente;
using Application.Utils;

namespace Api.Controllers
{
	[Route(RouteConstants.Cliente)]
	[ApiController]
	[Authorize]
	public class ClienteController : ControllerBase
	{
		private readonly IClienteService _clienteService;
		public ClienteController(IClienteService ClienteServices)
		{
			_clienteService = ClienteServices;
		}


		[HttpGet]
		[Route("{idCliente}")]
		public async Task<ActionResult> Get([FromRoute] int idCliente)
		{
			var result = await _clienteService.GetCliente(idCliente);

			return Ok(result);

		}
		[HttpGet]
		[Route("documento/{document}")]
		public async Task<ActionResult> GetByDocument([FromRoute] string document)
		{
			var result = await _clienteService.GetClienteByDocument(document);

			return Ok(result);

		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			var result = await _clienteService.GetAll();

			return Ok(result);

		}

		[HttpPost]
		[Route("Add")]
		public async Task<ActionResult> Add([FromBody] CadastroClienteDTO clienteDTO)
		{

			var result = await _clienteService.CadastraCliente(clienteDTO);

			return Ok(result);

		}


		[HttpPut]
		[Route("Update")]
		public async Task<ActionResult> Update([FromBody] ClienteDTO clienteDTO)
		{

			var result = await _clienteService.AtualizaCliente(clienteDTO);

			return Ok(result);

		}


	}
}
