using Entities.Application;

namespace Domain.Services.Interfaces
{
    public interface IUsuarioDomainService
	{
		Task AtualizaUsuario(UsuarioPoco usuario);		
		Task<UsuarioPoco> GetUser(string email, string senha);
		Task<List<UsuarioPoco>> GetAllFuncionarios();
		Task<List<UsuarioPoco>> GetAll();

		Task<UsuarioPoco> GetFuncionarioById(int idUsuario);
		Task<UsuarioPoco> GetUsuarioById(int idUsuario);
		Task CadastraUsuario(UsuarioPoco usuario);

	}
}
