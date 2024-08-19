using DTOs.DTOs.AtividadeOrdem;
using DTOs.DTOs.Cliente;
using DTOs.DTOs.DefeitoOrdem;
using DTOs.DTOs.Engenheiro;
using DTOs.DTOs.Equipamento;
using DTOs.DTOs.MaterialUtilizado;
using Entities.Application;


namespace DTOs.DTOs.OrdemServico
{
    public class OrdemServicoSimplesDTO
    {
		public int IdOrdem { get; set; }
		public DateTime DataHora { get; set; }
		public string? Numero { get; set; }
		public string? NumeroPrisma { get; set; }
		public string? Contato { get; set; }
		public string? NomeCliente { get; set; }
		public string? CargoCliente { get; set; }
		public string? RgCliente { get; set; }
		public string? TrabalhoConcluido { get; set; }
		public string? Telefone { get; set; }
		public string? Colp { get; set; }
		public string? Endereco { get; set; }
		public string? Equipamento { get; set; }
		public string? numSerie { get; set; }
		public DateTime? HoraInicio { get; set; }
		public DateTime? HoraFim { get; set; }
		public string? Atividade { get; set; }
		public string? Defeito { get; set; }
		public string? ComplementoAtividade { get; set; }
		public string? ComplementoDefeito { get; set; }
		public bool? Limpeza { get; set; }
		public bool? Ajuste { get; set; }
		public bool? Lubrificacao { get; set; }
		public string? Obs { get; set; }
		public string? NomeEngenheiro { get; set; }
		public string? Rg_Crea { get; set; }

		public ICollection<MaterialUtilizadoDTO>? MateriaisUtilizados { get; set; }
	}
}
