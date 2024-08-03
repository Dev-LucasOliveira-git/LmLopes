namespace Entities.Application
{
	public class DefeitoOrdemPoco
	{
		public int IdDefeito { get; set; }
		public int IdOrdemServico { get; set; }
		public bool Eletrico { get; set; }
		public bool Mecanico { get; set; }
		public bool Optico { get; set; }
		public bool Outros { get; set; }
		public string? Obs { get; set; }

		public OrdemServicoPoco OrdemServico { get; set; }
	}
}
