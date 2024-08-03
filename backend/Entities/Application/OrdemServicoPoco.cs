namespace Entities.Application
{
    public class OrdemServicoPoco
    {
        public int IdOrdem { get; set; }
        public DateTime DataHora { get; set; }
        public string Numero { get; set; }
        public string NumeroPrisma { get; set; }       
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public bool Limpeza { get; set; }
        public bool Ajuste {  get; set; }
        public bool Lubrificacao { get; set; }
        public string? Obs { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public int IdEngenheiro { get; set; }
        public int idEquipamento { get; set; }


        public UsuarioPoco Usuario { get; set; }
        public ClientePoco Cliente { get; set; }
        public EngenheiroPoco Engenheiro { get; set; }
        public EquipamentoPoco Equipamento { get; set; }
        public ICollection<MaterialUtilizadoPoco>? MateriaisUtilizados { get; set; }
		public AtividadeOrdemPoco? Atividade { get; set; }
		public DefeitoOrdemPoco? Defeito { get; set; }

	}
}
