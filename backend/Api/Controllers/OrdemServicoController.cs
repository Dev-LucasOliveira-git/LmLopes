using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Services.Interfaces;
using DTOs.DTOs.OrdemServico;
using Application.Utils;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using DTOs.DTOs.Ordem;

namespace Api.Controllers
{
	[Route(RouteConstants.OrdemServico)]
	[ApiController]
	[Authorize]
	public class OrdemServicoController : ControllerBase
	{
		private readonly IOrdemServicoService _ordemServicoService;
		public OrdemServicoController(IOrdemServicoService OrdemServicoService)
		{
			_ordemServicoService = OrdemServicoService;
		}

		[HttpGet]
		[Route("consulta/{idOrdemServico}")]
		public async Task<ActionResult> Get([FromRoute] int idOrdemServico)
		{
			var result = await _ordemServicoService.GetOrdemServico(idOrdemServico);

			return Ok(result);
		}

		[HttpGet]
		[Route("get")]
		public async Task<ActionResult> GetAll()
		{
			var result = await _ordemServicoService.GetAll();

			return Ok(result);
		}

		[HttpGet]
		public async Task<ActionResult> GetAllSimples()
		{
			var result = await _ordemServicoService.GetAllSimples();

			return Ok(result);
		}

		[HttpPost]
		[Route("Add")]

		public async Task<ActionResult> Add([FromBody] CadastroOrdemDTO OrdemServicoDTO)
		{

			var result = await _ordemServicoService.CadastrarOrdemServico(OrdemServicoDTO);

			return Ok(result);
		}

		[HttpPost]
		[Route("assinatura")]

		public async Task<ActionResult> AssinaOrdem([FromForm] AssinaturaOrdemUploadDTO imagem)
		{
			var result = await _ordemServicoService.ProcessaAssinaturaOrdemServico(imagem);
			return Ok(result);
		}

		[HttpGet]
		[Route("assinatura/{idOrdemServico}")]

		public async Task<IActionResult> GetAssinaturaOrdem([FromRoute] int idOrdemServico)
		{
			var result = await _ordemServicoService.GetAssinaturaOrdemServico(idOrdemServico);

			return this.File(result, "image/jpeg");
		}

		[HttpPost]
		public async Task<ActionResult> Insert([FromBody] CadastroOrdemSimplesDTO OrdemServicoDTO)
		{

			var result = await _ordemServicoService.CadastrarOrdemServico(OrdemServicoDTO);

			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult> Update([FromBody] OrdemServicoSimplesDTO OrdemServicoDTO)
		{

			var result = await _ordemServicoService.AtualizarOrdemServico(OrdemServicoDTO);

			return Ok(result);
		}

		[HttpPost]
		[Route("Cancelar/{idOrdemServico}")]
		public async Task<ActionResult> Cancelar([FromRoute] int idOrdemServico)
		{

			var result = await _ordemServicoService.CancelarOrdemServico(idOrdemServico);

			return Ok(result);
		}


	}
}
