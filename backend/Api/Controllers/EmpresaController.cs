using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.Utils;
using DTOs.DTOs.Empresa;

namespace Api.Controllers
{
    [Route(RouteConstants.Empresa)]
	[ApiController]
	public class EmpresaController : ControllerBase
	{
		private readonly IEmpresaService _empresaService;
		public EmpresaController(IEmpresaService empresaServices)
		{
			_empresaService = empresaServices;
		}


		[HttpGet]
		[Authorize]
		public async Task<ActionResult> Get()
		{
			var result = await _empresaService.GetEmpresa();

			if (result.IsSucesss)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpPut]
		[Authorize]
		[Route("Update")]

		public async Task<ActionResult> Update([FromBody] EmpresaDTO empresaDto)
		{

			var result = await _empresaService.AtualizaEmpresa(empresaDto);

			if (result.IsSucesss)
				return Ok(result);

			return BadRequest(result);
		}

	}
}
