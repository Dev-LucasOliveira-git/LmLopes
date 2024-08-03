using DTOs.DTOs.AtividadeOrdem;
using DTOs.DTOs.DefeitoOrdem;
using DTOs.DTOs.MaterialUtilizado;
using Entities.Application;

namespace DTOs.DTOs.OrdemServico
{
	public class CadastroOrdemDTO
	{
		public DateTime DataHora { get; set; }
		public string Numero { get; set; }
		public string NumeroPrisma { get; set; }
		public string Contato { get; set; }
		public string Telefone { get; set; }
		public bool Limpeza { get; set; }
		public bool Ajuste { get; set; }
		public bool Lubrificacao { get; set; }
		public string? Obs { get; set; }
		public int IdUsuario { get; set; }
		public int IdCliente { get; set; }
		public int IdEngenheiro { get; set; }
		public int idEquipamento { get; set; }

		public ICollection<MaterialUtilizadoDTO>? MateriaisUtilizados { get; set; }
		public AtividadeOrdemDTO? Atividade { get; set; }
		public DefeitoOrdemDTO? Defeito { get; set; }
	}
}
