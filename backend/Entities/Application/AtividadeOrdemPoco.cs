namespace Entities.Application
{
	public class AtividadeOrdemPoco
	{
		public int IdAtividade {  get; set; }
		public int IdOrdemServico { get; set; }
		public bool Preventiva { get; set; }
		public bool Corretiva { get; set; }
		public bool Instalalacao { get; set; }
		public bool Movimentacao { get; set; }
		public bool Outros { get; set; }
		public string? Obs {  get; set; }
		
		public OrdemServicoPoco OrdemServico { get; set; }
	}
}
