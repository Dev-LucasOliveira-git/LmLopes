using AutoMapper;
using Entities.Application;
using DTOs.DTOs.Cliente;
using DTOs.DTOs.OrdemServico;
using DTOs.DTOs.Usuario;
using DTOs.DTOs.Empresa;
using DTOs.DTOs.AtividadeOrdem;
using DTOs.DTOs.Engenheiro;
using DTOs.DTOs.Equipamento;
using DTOs.DTOs.DefeitoOrdem;
using DTOs.DTOs.MaterialUtilizado;

namespace Dto.Mappings
{
    public class DTOToDomainMapping : Profile
	{
		public DTOToDomainMapping()
		{

			CreateMap<AtividadeOrdemDTO, AtividadeOrdemPoco>();

			CreateMap<ClienteDTO, ClientePoco>();
			CreateMap<CadastroClienteDTO, ClientePoco>();

			CreateMap<DefeitoOrdemDTO, DefeitoOrdemPoco>();

			CreateMap<EmpresaDTO, EmpresaPoco>();

			CreateMap<EngenheiroDTO, EngenheiroPoco>();
			CreateMap<CadastroEngenheiroDTO, EngenheiroPoco>();

			CreateMap<EquipamentoDTO, EquipamentoPoco>();
			CreateMap<CadastroEquipamentoDTO, EquipamentoPoco>();

			CreateMap<MaterialUtilizadoDTO, MaterialUtilizadoPoco>();

			CreateMap<OrdemServicoDTO, OrdemServicoPoco>();
			CreateMap<CadastroOrdemDTO, OrdemServicoPoco>();

			CreateMap<UsuarioDTO, UsuarioPoco>();
			CreateMap<CadastroUsuarioDTO, UsuarioPoco>()
								.ForMember(dest => dest.Admin, opt => opt.MapFrom(src => src.TipoUsuario == "ADMIN" ? true : false));
		}
	}
}
