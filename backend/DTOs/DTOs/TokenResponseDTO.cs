using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.DTOs.Usuario;

namespace Dto.DTOs
{
    public class TokenResponseDTO
	{
		public UsuarioSessaoDTO usuario { get; set; }
		public string token { get; set; }
	}
}
