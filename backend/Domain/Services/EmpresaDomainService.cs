using Domain.Exceptions;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Entities.Application;


namespace Domain.Services
{
	public class EmpresaDomainService : IEmpresaDomainService
	{
		private readonly IEmpresaRepository _empresaRepository;


		public EmpresaDomainService(IEmpresaRepository empresaRepository)
		{
			_empresaRepository = empresaRepository;

		}

		public async Task AtualizaEmpresa(EmpresaPoco empresaPoco)
		{

			await _empresaRepository.Update(empresaPoco);

		}

		public async Task<EmpresaPoco> GetEmpresa()
		{

			var empresa = await _empresaRepository.GetAll();

			if (!empresa.Any())
				throw new EntityNotFound();

			return empresa.First();

		}
	}
}