using Domain.Repositories;
using Entities.Application;
using Domain.Services.Interfaces;
using Domain.Helpers;
using Domain.Exceptions;

namespace Domain.Services
{
	public class LoginDomainService : ILoginDomainService
	{
		private readonly IUsuarioRepository _usuarioRepository;
		

		public LoginDomainService(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;			
		}

		public async Task<UsuarioPoco> Login(string email, string senha)
		{

			var user = await _usuarioRepository.GetByExpression( x => x.Email == email && x.Senha == Criptografia.Encript(senha));

			if (!user.Any())
				throw new EntityNotFound("Usuario não encontrado. Verifique o email e senha informado");

			
			return user.First();

		}
	}
}