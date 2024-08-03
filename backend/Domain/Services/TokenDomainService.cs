using Domain.Authentication.Interface;
using Domain.Services.Interfaces;
using Entities.Application;
using Microsoft.AspNetCore.Http;


namespace Domain.Services
{
	public class TokenDomainService : ITokenDomainService
	{
		private readonly ITokenGenerator _tokenGenerator;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public TokenDomainService(ITokenGenerator tokenService, IHttpContextAccessor httpContextAccessor)
		{
			_tokenGenerator = tokenService;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<int> GetIdUsuario()
		{
			return _tokenGenerator.GetIdUsuarioFromJWT(_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty));
		}

		public async Task<string> GenerateToken(UsuarioPoco usuario)
		{
			return _tokenGenerator.GenerateToken(usuario);
		}
	}
}
