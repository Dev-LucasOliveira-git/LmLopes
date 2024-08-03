using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using DTOs.DTOs.Equipamento;
using Application.Utils;

namespace Api.Controllers
{
	[Route(RouteConstants.Equipamento)]
	[ApiController]
	[Authorize]
	public class EquipamentoController : ControllerBase
	{
		private readonly IEquipamentoService _equipamentoService;
		public EquipamentoController(IEquipamentoService EquipamentoServices)
		{
			_equipamentoService = EquipamentoServices;
		}


		[HttpGet]
		[Route("{idEquipamento}")]
		public async Task<ActionResult> Get([FromRoute] int idEquipamento)
		{
			var result = await _equipamentoService.GetEquipamento(idEquipamento);

			return Ok(result);

		}
		[HttpGet]
		[Route("documento/{document}")]
		public async Task<ActionResult> GetByDocument([FromRoute] string document)
		{
			var result = await _equipamentoService.GetEquipamentoByDocument(document);

			return Ok(result);

		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			var result = await _equipamentoService.GetAll();

			return Ok(result);

		}

		[HttpPost]
		[Route("Add")]
		public async Task<ActionResult> Add([FromBody] CadastroEquipamentoDTO equipamentoDTO)
		{

			var result = await _equipamentoService.CadastraEquipamento(equipamentoDTO);

			return Ok(result);

		}


		[HttpPut]
		[Route("Update")]
		public async Task<ActionResult> Update([FromBody] EquipamentoDTO equipamentoDTO)
		{

			var result = await _equipamentoService.AtualizaEquipamento(equipamentoDTO);

			return Ok(result);

		}


	}
}
