namespace DTOs.DTOs.DefeitoOrdem
{
	public class DefeitoOrdemDTO
	{
		public int IdOrdemServico { get; set; }
		public bool Eletrico { get; set; }
		public bool Mecanico { get; set; }
		public bool Optico { get; set; }
		public bool Outros { get; set; }
		public string? Obs { get; set; }
	}
}
