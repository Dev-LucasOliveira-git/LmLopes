using AutoMapper;
using Entities.Application;
using DTOs.DTOs.Cliente;
using DTOs.DTOs.OrdemServico;
using DTOs.DTOs.Usuario;
using DTOs.DTOs.Empresa;
using DTOs.DTOs.Engenheiro;
using DTOs.DTOs.Equipamento;
using DTOs.DTOs.AtividadeOrdem;
using DTOs.DTOs.MaterialUtilizado;
using DTOs.DTOs.DefeitoOrdem;


namespace Dto.Mappings
{
    public class DomainToDTOMapping : Profile
	{
		public DomainToDTOMapping()
		{

			CreateMap<AtividadeOrdemPoco, AtividadeOrdemDTO>();

			CreateMap<ClientePoco, ClienteDTO>();

			CreateMap<DefeitoOrdemPoco, DefeitoOrdemDTO>();



			CreateMap<EmpresaPoco, EmpresaDTO>();

			CreateMap<EngenheiroPoco, EngenheiroDTO>();

			CreateMap<EquipamentoPoco, EquipamentoDTO>();

			CreateMap<OrdemServicoPoco, OrdemServicoDTO>()
			   .ForMember(dest => dest.Engenheiro, opt => opt.MapFrom(src => src.Engenheiro))
			   .ForMember(dest => dest.Equipamento, opt => opt.MapFrom(src => src.Equipamento))
       		   .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
			   .ForMember(dest => dest.MateriaisUtilizados, opt => opt.MapFrom(src => src.MateriaisUtilizados))
			   .ForMember(dest => dest.Atividade, opt => opt.MapFrom(src => src.Atividade))
			   .ForMember(dest => dest.Defeito, opt => opt.MapFrom(src => src.Defeito));

			CreateMap<OrdemServicoSimplesPoco, OrdemServicoSimplesDTO>()
				.ForMember(dest => dest.MateriaisUtilizados, opt => opt.MapFrom(src => src.MateriaisUtilizados));


			CreateMap<MaterialUtilizadoPoco, MaterialUtilizadoDTO>();

			CreateMap<UsuarioPoco, UsuarioDTO>()
				.ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.Admin ? "ADMIN" : "FUNC"));

			CreateMap<UsuarioPoco, UsuarioSessaoDTO>()
				.ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.Admin ? "ADMIN" : "FUNC"));

		}
	}
}
