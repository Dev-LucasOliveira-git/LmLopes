using Domain.Exceptions;
using Application.Services;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Application.CustomMiddlewares
{
    public class ExceptionHandlingMiddleware : AbstractExceptionHandlerMiddleware
    {
        public ExceptionHandlingMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            HttpStatusCode code;
            switch (exception)
            {
                case KeyNotFoundException
                    or UserNotFoundException
                    or FileNotFoundException
                    or EntityNotFound:
                    code = HttpStatusCode.NotFound;
                    break;
                case EntityAlreadyExists:
                    code = HttpStatusCode.Conflict;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ArgumentException
                    or InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }
            return (code, JsonSerializer.Serialize(ResultService.Fail(exception.Message)));
        }
    }
}