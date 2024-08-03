using Domain.Authentication.Interface;
using Entities.Application;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Authentication
{
	public class TokenGenerator : ITokenGenerator
	{
		public string GenerateToken(UsuarioPoco usuario)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Role,usuario.Admin ? "Admin" : "Func" ),
					new Claim("idUsuario", usuario.IdUsuario.ToString()),
				}),
				Expires = DateTime.UtcNow.AddHours(8),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}		

		public int GetIdUsuarioFromJWT(string token)
		{
			var jwtToken = ValidateToken(token);
			var idUsuario = int.Parse(jwtToken.Claims.First(x => x.Type == "idUsuario").Value);
			return idUsuario;
		}


		public static JwtSecurityToken ValidateToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var SecretKey = Settings.Secret;
			var key = Encoding.ASCII.GetBytes(SecretKey);

			tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false,
				ClockSkew = TimeSpan.Zero
			}, out SecurityToken validatedToken);

			return (JwtSecurityToken)validatedToken;
		}
	}
}
