using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Application;


namespace Domain.Services
{
	public class OrdemServicoDomainService : IOrdemServicoDomainService
	{
		private readonly IOrdemServicoRepository _ordemServicoRepository;
		private readonly IOrdemServicoSimplesRepository _ordemServicoSimplesRepository;
		private readonly ITokenDomainService _tokenDomainService;



		public OrdemServicoDomainService(IOrdemServicoRepository ordemServicoRepository,
									IOrdemServicoSimplesRepository ordemServicoSimplesRepository,
								  ITokenDomainService tokenDomainService)
		{
			_ordemServicoRepository = ordemServicoRepository;
			_ordemServicoSimplesRepository = ordemServicoSimplesRepository;
			_tokenDomainService = tokenDomainService;
		}

		public async Task CadastrarOrdemServico(OrdemServicoPoco OrdemServico)
		{

			OrdemServico.IdUsuario = await _tokenDomainService.GetIdUsuario();

			OrdemServico.DataHora = DateTime.Now;

			await _ordemServicoRepository.Add(OrdemServico);
		}

		public async Task CadastrarOrdemServico(OrdemServicoSimplesPoco OrdemServico)
		{

			OrdemServico.IdUsuario = await _tokenDomainService.GetIdUsuario();

			OrdemServico.DataHora = DateTime.Now;

			await _ordemServicoSimplesRepository.Add(OrdemServico);
		}

		public async Task CancelarOrdemServico(int idOrdemServico)
		{
			await _ordemServicoRepository.Delete(null);

		}

		public async Task<List<OrdemServicoPoco>> GetAll()
		{

			var OrdemServicos = await _ordemServicoRepository.GetAll();
			return OrdemServicos;
		}

		public async Task<List<OrdemServicoSimplesPoco>> GetAllSimples()
		{

			var OrdemServicos = await _ordemServicoSimplesRepository.GetAll();
			return OrdemServicos;
		}
		public async Task<OrdemServicoPoco> GetOrdemServico(int idOrdemServico)
		{

			var ordemServicos = await _ordemServicoRepository.GetByExpression(x => x.IdOrdem == idOrdemServico,
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
