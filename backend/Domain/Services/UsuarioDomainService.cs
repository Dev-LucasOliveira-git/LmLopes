using Domain.Exceptions;
using Domain.Helpers;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Entities.Application;


namespace Domain.Services
{
	public class UsuarioDomainService : IUsuarioDomainService
	{
		private readonly IUsuarioRepository _usuarioRepository;

		private readonly ITokenDomainService _tokenDomainService;
		public UsuarioDomainService(IUsuarioRepository usuarioRepository, ITokenDomainService tokenDomainService)
		{
			_usuarioRepository = usuarioRepository;
			_tokenDomainService = tokenDomainService;
		}
		public async Task AtualizaUsuario(UsuarioPoco usuarioPoco)
		{
			usuarioPoco.DataHoraUltimaAlteracao = DateTime.Now;
			usuarioPoco.IdUsuarioUltimaAlteracao = await _tokenDomainService.GetIdUsuario();

			await _usuarioRepository.Update(usuarioPoco);
		}

		public async Task CadastraUsuario(UsuarioPoco usuarioPoco)
		{
			usuarioPoco.DataHoraCadastro = usuarioPoco.DataHoraUltimaAlteracao = DateTime.Now;
			usuarioPoco.IdUsuarioCadastro = usuarioPoco.IdUsuarioUltimaAlteracao = await _tokenDomainService.GetIdUsuario();
			usuarioPoco.Senha = Criptografia.Encript(usuarioPoco.Senha);
			await _usuarioRepository.Add(usuarioPoco);

		}

		public async Task<List<UsuarioPoco>> GetAllFuncionarios()
		{

			var funcionarios = await _usuarioRepository.GetByExpression(x => !x.Admin);
			return funcionarios;

		}
		public async Task<List<UsuarioPoco>> GetAll()
		{

			var funcionarios = await _usuarioRepository.GetAll();
			return funcionarios;

		}


		public async Task<UsuarioPoco> GetFuncionarioById(int idUsuario)
		{

			var funcionario = await _usuarioRepository.GetEntityById(idUsuario);
			if (funcionario == null)
				throw new EntityNotFound();
			return funcionario;

		}

		public async Task<UsuarioPoco> GetUser(string email , string senha)
		{
			var usuarioPoco = await _usuarioRepository.GetByExpression(x => x.Email == email && x.Senha == senha);

			if (usuarioPoco == null)
				throw new EntityNotFound();

			return usuarioPoco.First();
		}

		public async Task<UsuarioPoco> GetUsuarioById(int idUsuario)
		{

			var usuario = await _usuarioRepository.GetEntityById(idUsuario);

			if (usuario == null)
				throw new EntityNotFound();

			return usuario;

		}
	}
}
