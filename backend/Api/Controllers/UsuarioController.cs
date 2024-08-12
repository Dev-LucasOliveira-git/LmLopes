using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Dto.DTOs;
using DTOs.DTOs.Usuario;
using Application.Utils;

namespace Api.Controllers
{
	[Route(RouteConstants.Usuario)]
	[ApiController]
	[Authorize]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;
		public UsuarioController(IUsuarioService usuarioServices)
		{
			_usuarioService = usuarioServices;
		}


		[HttpGet]
		[Route("Login")]

		public async Task<ActionResult> Get(LoginDTO loginDto)
		{
			var result = await _usuarioService.GetUser(loginDto);

			if (result.IsSucesss)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpPost]
		[Route("Add")]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult> Add([FromBody] CadastroUsuarioDTO usuario)
		{

			var result = await _usuarioService.CadastraUsuario(usuario);

			if (result.IsSucesss)
				return Ok(result);

			return BadRequest(result);
		}


		[HttpPut]
		[Route("Update")]
		[Authorize(Roles = "Admin")]

		public async Task<ActionResult> Update([FromBody] UsuarioDTO usuario)
		{

			var result = await _usuarioService.AtualizaUsuario(usuario);

			if (result.IsSucesss)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpGet]
		[Route("funcionarios/{idUsuario}")]
		public async Task<ActionResult> GetVendedorById([FromRoute] int idUsuario)
		{

			var result = await _usuarioService.GetFuncionarioById(idUsuario);

			if (result.IsSucesss)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpGet]
		[Route("funcionarios")]
		public async Task<ActionResult> GetAllfuncionarios()
		{

			var result = await _usuarioService.GetAllFuncionarios();

			if (result.IsSucesss)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{

			var result = await _usuarioService.GetAll();

			if (result.IsSucesss)
				return Ok(result);

			return BadRequest(result);
		}
	}
}
