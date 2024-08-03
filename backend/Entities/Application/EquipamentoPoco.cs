namespace Entities.Application
{
	public class EquipamentoPoco
	{

		public int IdEquipamento { get; set; }
		public string Nome { get; set; }
		public string NumeroSerie { get; set; }
		public string Tags { get; set; }

		public ICollection<OrdemServicoPoco>? OrdensServicos { get; set; }

	}
}
