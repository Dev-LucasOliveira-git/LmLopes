using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.Ordem
{
	public class AssinaturaOrdemUploadDTO
	{
		public int IdOrdem { get; set; }
		public IFormFile ImgAssinaturaCliente { get; set; }
		public IFormFile ImgAssinaturaEngenheiro { get; set; }

	}
}
