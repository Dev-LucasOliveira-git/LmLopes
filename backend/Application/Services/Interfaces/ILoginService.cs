using Dto.DTOs;

namespace Application.Services.Interfaces
{
	public interface ILoginService
	{
		Task<ResultService> Login(LoginDTO usuario);
	}
}
