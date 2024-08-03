using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
	public static class Criptografia
	{
		public static string Encript(this string password)
		{
			var hash = MD5.Create();
			var encoding = new ASCIIEncoding();
			var array = encoding.GetBytes(password);

			array = hash.ComputeHash(array);

			var strHexa = new StringBuilder();

			foreach (var item in array)
			{
				strHexa.Append(item.ToString("x2"));
			}

			return strHexa.ToString();
		}
	}
}
