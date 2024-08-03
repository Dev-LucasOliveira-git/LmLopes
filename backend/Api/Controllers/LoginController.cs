using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Dto.DTOs;
using Application.Utils;

namespace Api.Controllers
{
	[Route(RouteConstants.Login)]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _loginService;
		public LoginController(ILoginService tokenService)
		{
			_loginService = tokenService;
		}

		[HttpPost]
		public async Task<ActionResult> Login([FromBody]LoginDTO loginDto)
		{
			var result = await _loginService.Login(loginDto);

			return Ok(result);

		}

	}
}
