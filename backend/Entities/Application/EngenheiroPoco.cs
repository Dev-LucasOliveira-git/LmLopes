namespace Entities.Application
{
	public class EngenheiroPoco
	{
		public int IdEngenheiro { get; set; }
		public string Nome { get; set; }
		public string RG {  get; set; }
		public string CREA { get; set; }

		public ICollection<OrdemServicoPoco>? OrdensServicos { get; set; }

	}
}
