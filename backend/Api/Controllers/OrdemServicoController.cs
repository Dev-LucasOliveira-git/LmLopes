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
		[Route("assinaturas")]

		public async Task<ActionResult> AssinaOrdemCliente([FromForm] AssinaturaOrdemUploadDTO imagem)
		{
			var result = await _ordemServicoService.ProcessaAssinaturasOrdemServico(imagem);
			return Ok(result);
		}


		[HttpGet]
		[Route("assinaturas/{idOrdemServico}")]

		public async Task<ActionResult> GetClienteAssinaturaOrdem([FromRoute] int idOrdemServico)
		{
			var result = await _ordemServicoService.GetAssinaturasOrdemServico(idOrdemServico);

			return Ok(result);
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
