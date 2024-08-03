using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using DTOs.DTOs.Engenheiro;
using Application.Utils;

namespace Api.Controllers
{
	[Route(RouteConstants.Engenheiro)]
	[ApiController]
	[Authorize]
	public class EngenheiroController : ControllerBase
	{
		private readonly IEngenheiroService _engenheiroService;
		public EngenheiroController(IEngenheiroService EngenheiroServices)
		{
			_engenheiroService = EngenheiroServices;
		}


		[HttpGet]
		[Route("{idEngenheiro}")]
		public async Task<ActionResult> Get([FromRoute] int idEngenheiro)
		{
			var result = await _engenheiroService.GetEngenheiro(idEngenheiro);

			return Ok(result);

		}
		[HttpGet]
		[Route("documento/{document}")]
		public async Task<ActionResult> GetByDocument([FromRoute] string document)
		{
			var result = await _engenheiroService.GetEngenheiroByDocument(document);

			return Ok(result);

		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			var result = await _engenheiroService.GetAll();

			return Ok(result);

		}

		[HttpPost]
		[Route("Add")]
		public async Task<ActionResult> Add([FromBody] CadastroEngenheiroDTO engenheiroDTO)
		{

			var result = await _engenheiroService.CadastraEngenheiro(engenheiroDTO);

			return Ok(result);

		}


		[HttpPut]
		[Route("Update")]
		public async Task<ActionResult> Update([FromBody] EngenheiroDTO engenheiroDTO)
		{

			var result = await _engenheiroService.AtualizaEngenheiro(engenheiroDTO);

			return Ok(result);

		}


	}
}
