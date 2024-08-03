namespace DTOs.DTOs.AtividadeOrdem
{
	public class AtividadeOrdemDTO
	{
		public int IdOrdemServico { get; set; }
		public bool Preventiva { get; set; }
		public bool Corretiva { get; set; }
		public bool Instalalacao { get; set; }
		public bool Movimentacao { get; set; }
		public bool Outros { get; set; }
		public string? Obs { get; set; }
	}
}
