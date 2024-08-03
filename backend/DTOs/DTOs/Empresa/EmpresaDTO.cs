using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Empresa
{
    public class EmpresaDTO
    {
		public int IdEmpresa { get; set; }
		public string RazaoSocial { get; set; }
		public string Cnpj { get; set; }
		public string? Email { get; set; }
		public string? Telefone { get; set; }
		public string? Endereco { get; set; }
		public string? Bairro { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public int? IdCidade { get; set; }
		public int? IdEstado { get; set; }
		public string CaminhoImagem { get; set; }
	}
}
