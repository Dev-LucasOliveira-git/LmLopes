namespace Entities.Application
{
    public class CidadePoco
    {
        public int IdCidade { get ; set; }
        public string Nome { get; set; }
        public int IdEstado { get; set; }


		public EstadoPoco Estado { get; set; }


	}
}
