using AutoMapper;
using Application.Services.Interfaces;
using Dto.DTOs;
using Entities.Application;
using DTOs.DTOs.Usuario;
using Domain.Services.Interfaces;

namespace Application.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioDomainService _usuarioDomainService;
		private readonly IMapper _mapper;
		public UsuarioService(IUsuarioDomainService usuarioDomainService, IMapper mapper)
		{
			_usuarioDomainService = usuarioDomainService;
			_mapper = mapper;
		}
		public async Task<ResultService> AtualizaUsuario(UsuarioDTO usuario)
		{
			var usuarioPoco = _mapper.Map<UsuarioPoco>(usuario);

			await _usuarioDomainService.AtualizaUsuario(usuarioPoco);
			return ResultService.Ok(usuario);
		}

		public async Task<ResultService> CadastraUsuario(CadastroUsuarioDTO usuario)
		{
			var usuarioPoco = _mapper.Map<UsuarioPoco>(usuario);
			await _usuarioDomainService.CadastraUsuario(usuarioPoco);
			return ResultService.Ok(usuario);

		}

		public async Task<ResultService> GetAllFuncionarios()
		{

			var funcionarios = await _usuarioDomainService.GetAllFuncionarios();
			return ResultService.Ok(_mapper.Map<List<UsuarioDTO>>(funcionarios));

		}

		public async Task<ResultService> GetAll()
		{

			var funcionarios = await _usuarioDomainService.GetAll();
			return ResultService.Ok(_mapper.Map<List<UsuarioDTO>>(funcionarios));

		}

		public async Task<ResultService> GetFuncionarioById(int idUsuario)
		{

			var funcionario = await _usuarioDomainService.GetFuncionarioById(idUsuario);
			return ResultService.Ok(_mapper.Map<UsuarioDTO>(funcionario));

		}

		public async Task<ResultService> GetUser(LoginDTO loginDto)
		{
			var usuarioPoco = await _usuarioDomainService.GetUser(loginDto.Email,loginDto.Senha);
			return ResultService.Ok(usuarioPoco);
		}

		public async Task<ResultService> GetUsuarioById(int idUsuario)
		{

			var usuario = await _usuarioDomainService.GetUsuarioById(idUsuario);
			return ResultService.Ok(_mapper.Map<UsuarioDTO>(usuario));

		}
	}
}
