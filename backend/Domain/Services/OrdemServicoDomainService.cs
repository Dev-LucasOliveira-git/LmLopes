using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Application;


namespace Domain.Services
{
	public class OrdemServicoDomainService : IOrdemServicoDomainService
	{
		private readonly IOrdemServicoRepository _OrdemServicoRepository;
		private readonly ITokenDomainService _tokenDomainService;



		public OrdemServicoDomainService(IOrdemServicoRepository OrdemServicoRepository,
								  ITokenDomainService tokenDomainService)
		{
			_OrdemServicoRepository = OrdemServicoRepository;
			_tokenDomainService = tokenDomainService;
		}

		public async Task CadastrarOrdemServico(OrdemServicoPoco OrdemServico)
		{

			OrdemServico.IdUsuario = await _tokenDomainService.GetIdUsuario();

			OrdemServico.DataHora = DateTime.Now;

			await _OrdemServicoRepository.Add(OrdemServico);




		}

		public async Task CancelarOrdemServico(int idOrdemServico)
		{
			await _OrdemServicoRepository.Delete(null);

		}

		public async Task<List<OrdemServicoPoco>> GetAll()
		{

			var OrdemServicos = await _OrdemServicoRepository.GetAll();
			return OrdemServicos;
		}

		public async Task<OrdemServicoPoco> GetOrdemServico(int idOrdemServico)
		{

			var ordemServicos = await _OrdemServicoRepository.GetByExpression(x => x.IdOrdem == idOrdemServico,
																			   "Engenheiro",
																			   "Equipamento",
																			   "MateriaisUtilizados",
																			   "Cliente",
																			   "Atividade",
																			   "Defeito",
																			   "Usuario"
																			   );

			var ordemServico = ordemServicos.FirstOrDefault();

			if (ordemServico == null)
				throw new EntityNotFound();

			return ordemServico;

		}
	}
}
