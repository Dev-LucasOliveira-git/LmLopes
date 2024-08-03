using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Cliente
{
    public class ClienteDTO
    {
		public int IdCliente { get; set; }
		public string Nome { get; set; }
		public string? Email { get; set; }
		public string? CpfCnpj { get; set; }
		public string? Telefone { get; set; }
		public string? Endereco { get; set; }
		public string? Bairro { get; set; }
		public string? Numero { get; set; }
		public string? Cep { get; set; }
		public string? Complemento { get; set; }

	}
}
