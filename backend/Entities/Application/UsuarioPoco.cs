namespace Entities.Application
{
    public class UsuarioPoco
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public bool Admin { get; set; }
		public string CaminhoImagem { get; set; }
		public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraUltimaAlteracao { get; set; }
		public int IdUsuarioCadastro { get; set; }
		public int IdUsuarioUltimaAlteracao { get; set; }

		public UsuarioPoco UsuarioCadastro { get; set; }
		public UsuarioPoco UsuarioUltimaAlteracao { get; set; }
		public ICollection<ClientePoco>? ClientesCadastrados { get; set; }
		public ICollection<ClientePoco>? ClientesUltimaAlteracao { get; set; }
		public ICollection<OrdemServicoPoco>? OrdensServicos { get; set; }

    }
}
