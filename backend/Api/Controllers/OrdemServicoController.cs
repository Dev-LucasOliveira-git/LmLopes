using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Services.Interfaces;
using DTOs.DTOs.OrdemServico;
using Application.Utils;

namespace Api.Controllers
{
	[Route(RouteConstants.OrdemServico)]
	[ApiController]
	[Authorize]
	public class OrdemServicoController : ControllerBase
	{
		private readonly IOrdemServicoService _OrdemServicoService;
		public OrdemServicoController(IOrdemServicoService OrdemServicoService)
		{
			_OrdemServicoService = OrdemServicoService;
		}

		[HttpGet]
		[Route("GetOrdemServico/{idOrdemServico}")]
		public async Task<ActionResult> Get([FromRoute] int idOrdemServico)
		{
			var result = await _OrdemServicoService.GetOrdemServico(idOrdemServico);

			return Ok(result);
		}

		[HttpGet]


		public async Task<ActionResult> GetAll()
		{
			var result = await _OrdemServicoService.GetAll();

			return Ok(result);
		}

		[HttpPost]
		[Route("Add")]

		public async Task<ActionResult> Add([FromBody] CadastroOrdemDTO OrdemServicoDTO)
		{

			var result = await _OrdemServicoService.CadastrarOrdemServico(OrdemServicoDTO);

			return Ok(result);
		}


		[HttpPost]
		[Route("Cancelar/{idOrdemServico}")]
		public async Task<ActionResult> Cancelar([FromRoute] int idOrdemServico)
		{

			var result = await _OrdemServicoService.CancelarOrdemServico(idOrdemServico);

			return Ok(result);
		}


	}
}
