using Entities.Application;

namespace Domain.Authentication.Interface
{
    public interface ITokenGenerator
    {
        string GenerateToken(UsuarioPoco usuario);
        int GetIdUsuarioFromJWT(string token);

    }
}
