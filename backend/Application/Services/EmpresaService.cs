using AutoMapper;
using Application.Services.Interfaces;
using Entities.Application;
using Domain.Services.Interfaces;
using DTOs.DTOs.Empresa;

namespace Application.Services
{
    public class EmpresaService : IEmpresaService
	{
		private readonly IEmpresaDomainService _empresaDomainService;
		private readonly IMapper _mapper;

		public EmpresaService(IEmpresaDomainService empresaDomainService, IMapper mapper)
		{
			_empresaDomainService = empresaDomainService;
			_mapper = mapper;
		}

		public async Task<ResultService> AtualizaEmpresa(EmpresaDTO empresa)
		{
			var empresaPoco = _mapper.Map<EmpresaPoco>(empresa);

			await _empresaDomainService.AtualizaEmpresa(empresaPoco);
			return ResultService.Ok();

		}

		public async Task<ResultService> GetEmpresa()
		{

				var empresa = await _empresaDomainService.GetEmpresa();

				var mapcom = _mapper.Map<EmpresaDTO>(empresa);

				return ResultService.Ok(mapcom);

		}
	}
}