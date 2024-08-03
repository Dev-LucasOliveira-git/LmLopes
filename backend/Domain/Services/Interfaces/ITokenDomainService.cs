using Entities.Application;

namespace Domain.Services.Interfaces
{
	public interface ITokenDomainService
	{
		Task<int> GetIdUsuario();
		Task<string> GenerateToken(UsuarioPoco usuario);
	}
}
