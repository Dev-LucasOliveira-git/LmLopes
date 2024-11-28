using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Application;
using Microsoft.AspNetCore.Http;


namespace Domain.Services
{
	public class OrdemServicoDomainService : IOrdemServicoDomainService
	{
		private readonly IOrdemServicoRepository _ordemServicoRepository;
		private readonly IOrdemServicoSimplesRepository _ordemServicoSimplesRepository;
		private readonly ITokenDomainService _tokenDomainService;
		private readonly IMaterialUtilizadoRepository _materialUtilizadoRepository;


		public OrdemServicoDomainService(IOrdemServicoRepository ordemServicoRepository,
									IOrdemServicoSimplesRepository ordemServicoSimplesRepository,
								  ITokenDomainService tokenDomainService,
								  IMaterialUtilizadoRepository materialUtilizadoRepository)
		{
			_ordemServicoRepository = ordemServicoRepository;
			_ordemServicoSimplesRepository = ordemServicoSimplesRepository;
			_tokenDomainService = tokenDomainService;
			_materialUtilizadoRepository = materialUtilizadoRepository;
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

		public async Task AtualizarOrdemServico(OrdemServicoSimplesPoco ordemServico)
		{

			ordemServico.IdUsuario = await _tokenDomainService.GetIdUsuario();

			var entityOld = await _ordemServicoSimplesRepository.GetEntityById(ordemServico.IdOrdem);

			if (entityOld != null)
			{
				ordemServico.ImgAssinaturaCliente = entityOld.ImgAssinaturaCliente;
				ordemServico.ImgAssinaturaEngenheiro = entityOld.ImgAssinaturaEngenheiro;

				await _ordemServicoSimplesRepository.ExecuteInTransactionAsync(async () =>
				{
					await _materialUtilizadoRepository.DeleteRangeAsync(x => x.IdOrdemServicoSimples == ordemServico.IdOrdem);										
					await _ordemServicoSimplesRepository.Update(ordemServico);		

				});
			}
			else
				throw new EntityNotFound("Ordem de Serviço não encontrada");
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

			var OrdemServicos = await _ordemServicoSimplesRepository.GetAll("MateriaisUtilizados");
			return OrdemServicos;
		}
		public async Task<OrdemServicoSimplesPoco> GetOrdemServico(int idOrdemServico)
		{

			var ordemServicos = await _ordemServicoSimplesRepository.GetByExpression(x => x.IdOrdem == idOrdemServico,
																			   "MateriaisUtilizados"
																			   );

			var ordemServico = ordemServicos.FirstOrDefault();

			if (ordemServico == null)
				throw new EntityNotFound();

			return ordemServico;

		}

		public async Task ProcessaAssinaturasOrdem(int idOrdem, List<byte[]> imagens)
		{
			
			var entity = await _ordemServicoSimplesRepository.GetEntityById(idOrdem);

			if (entity != null)
			{
				entity.ImgAssinaturaCliente = imagens[0];
				entity.ImgAssinaturaEngenheiro = imagens[1];

				await _ordemServicoSimplesRepository.ExecuteInTransactionAsync(async () =>
				{
					await _ordemServicoSimplesRepository.Update(entity);

				});
			}
			else
				throw new EntityNotFound("Ordem de Serviço não encontrada");
		}

		public async Task<List<byte[]>> GetAssinaturasOrdem(int idOrdem)
		{

			var entity = await _ordemServicoSimplesRepository.GetEntityById(idOrdem);

			if (entity != null)
			{
				return new List<byte[]> { entity.ImgAssinaturaEngenheiro,entity.ImgAssinaturaCliente};
			}
			else
				throw new EntityNotFound("Ordem de Serviço não encontrada");
		}
	}
}
