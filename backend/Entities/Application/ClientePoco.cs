namespace Entities.Application
{
    public class ClientePoco
    {
        public int IdCliente { get; set; }
		public string Nome { get; set; }
		public string? Email { get; set; }
		public string? Telefone { get; set; }
		public string? Endereco { get; set; }
		public string? CEP { get; set; }
		public string? CpfCnpj { get; set; }
		public string? Bairro { get; set; }
		public string? Numero { get; set; }
		public string? Complemento { get; set; }
		public int? IdCidade { get; set; }
		public int? IdEstado { get; set; }
		public DateTime DataHoraCadastro { get; set; }
		public DateTime DataHoraUltimaAlteracao { get; set; }
		public int IdUsuarioCadastro { get; set; }
        public int IdUsuarioUltimaAlteracao { get; set; }

        public CidadePoco Cidade { get; set; }
        public EstadoPoco Estado { get; set; }
        public UsuarioPoco UsuarioCadastro { get; set; }
        public UsuarioPoco UsuarioUltimaAlteracao { get; set; }


        public ICollection<OrdemServicoPoco>? OrdensServicos { get; set; }
    }
}
