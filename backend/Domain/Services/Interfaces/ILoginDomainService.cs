using Entities.Application;

namespace Domain.Services.Interfaces
{
	public interface ILoginDomainService
	{
		Task<UsuarioPoco> Login(string email, string senha);
	}
}
