using Domain.Helpers;
using FluentValidation.Results;

namespace Application.Utils
{
	public class ResultService 
	{
		public bool IsSucesss { get; set; }
		public string Message { get; set; }
		public ICollection<ErrorValidation> Errors { get; set; }

		public static ResultService RequestError(string message, ValidationResult validationResult)
		{
			return new ResultService()
			{
				IsSucesss = false,
				Message = message,
				Errors = validationResult.Errors.Select(i => new ErrorValidation() { Field = i.PropertyName, Message = i.ErrorMessage }).ToList()
			};
		}

		public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
		{
			return new ResultService<T>()
			{
				IsSucesss = false,
				Message = message,
				Errors = validationResult.Errors.Select(i => new ErrorValidation() { Field = i.PropertyName, Message = i.ErrorMessage }).ToList()
			};
		}

		public static ResultService Fail(string message) => new ResultService() { IsSucesss = false, Message = message };
		public static ResultService<T> Fail<T>(string message,T data) => new ResultService<T>() { IsSucesss = false, Message = message, Data = data };
		public static ResultService Ok(string message) => new ResultService() { IsSucesss = true, Message = message };
		public static ResultService Ok() => new ResultService() { IsSucesss = true, Message = "Solicitação processada com sucesso" };
		public static ResultService<T> Ok<T>(T data) =>  new ResultService<T>() { IsSucesss = true, Data = data };
	}

	public class ResultService<T> : ResultService
	{
		public T Data { get; set; }
	}
}
