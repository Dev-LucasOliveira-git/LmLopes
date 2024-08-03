namespace Domain.Exceptions
{
    public class EntityAlreadyExists : Exception
    {
		public EntityAlreadyExists() : base("Já Existe uma entidade na Base de Dados com o mesmo código identificador")
		{

		}
		public EntityAlreadyExists(string message) : base(message)
		{

		}
	}
}
