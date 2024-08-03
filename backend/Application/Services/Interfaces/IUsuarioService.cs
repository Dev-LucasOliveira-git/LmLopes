using Dto.DTOs;
using DTOs.DTOs.Usuario;
using Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUsuarioService
	{
		Task<ResultService> AtualizaUsuario(UsuarioDTO usuario);		
		Task<ResultService> GetUser(LoginDTO usuario);
		Task<ResultService> GetAllFuncionarios();
		Task<ResultService> GetAll();
		Task<ResultService> GetFuncionarioById(int idUsuario);
		Task<ResultService> GetUsuarioById(int idUsuario);
		Task<ResultService> CadastraUsuario(CadastroUsuarioDTO usuario);

	}
}
