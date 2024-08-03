namespace Domain.Exceptions
{
    public class EntityNotFound : Exception
    {
		public EntityNotFound() : base("Entidade Não Encontrada na Base de Dados")
		{

		}

		public EntityNotFound(string message) : base(message)
		{

		}
	}
}
