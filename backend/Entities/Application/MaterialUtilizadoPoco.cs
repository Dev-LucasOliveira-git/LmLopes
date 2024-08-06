namespace Entities.Application
{
	public class MaterialUtilizadoPoco
	{
		public int IdMaterialUtilizado { get; set; }
		public string Descricao { get; set; }
		public decimal Quantidade { get; set; }
		public int? IdOrdemServico { get; set; }
		public int? IdOrdemServicoSimples { get; set; }

		public OrdemServicoPoco? OrdemServico { get; set; }
		public OrdemServicoSimplesPoco? OrdemServicoSimples { get; set; }

	}
}
