using AutoMapper;
using Application.Services.Interfaces;
using Dto.DTOs;
using DTOs.DTOs.Usuario;
using Domain.Services.Interfaces;

namespace Application.Services
{
	public class LoginService : ILoginService
	{
		private readonly ILoginDomainService _loginDomainService;
		private readonly ITokenDomainService _tokenDomainService;

		private readonly IMapper _mapper;

		public LoginService(ILoginDomainService loginDomainService, IMapper mapper, ITokenDomainService tokenDomainService)
		{
			_loginDomainService = loginDomainService;
			_mapper = mapper;
			_tokenDomainService = tokenDomainService;
		}

		public async Task<ResultService> Login(LoginDTO loginDto)
		{

			var usuario = await _loginDomainService.Login(loginDto.Email,loginDto.Senha);

			var tokenResponse = new TokenResponseDTO();

			tokenResponse.usuario = _mapper.Map<UsuarioSessaoDTO>(usuario);

			tokenResponse.token = await _tokenDomainService.GenerateToken(usuario);

			return ResultService.Ok(tokenResponse);

		}
	}
}