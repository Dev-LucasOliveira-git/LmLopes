using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Application;

namespace Domain.Services
{
	public class EngenheiroDomainService : IEngenheiroDomainService
	{
		private readonly IEngenheiroRepository _engenheiroRepository;

		public EngenheiroDomainService(IEngenheiroRepository engenheiroRepository)
		{
			_engenheiroRepository = engenheiroRepository;

		}
		public async Task AtualizaEngenheiro(EngenheiroPoco engenheiroPoco)
		{


			var engenheiroPocoOld = await _engenheiroRepository.GetEntityById(engenheiroPoco.IdEngenheiro);

			if (engenheiroPocoOld == null)
				throw new EntityNotFound("Engenheiro não encontrado");


			engenheiroPocoOld.Nome = engenheiroPoco.Nome;
			engenheiroPocoOld.RG = engenheiroPoco.RG;
			engenheiroPocoOld.CREA = engenheiroPoco.CREA;

			await _engenheiroRepository.Update(engenheiroPocoOld);
		}

		public async Task CadastraEngenheiro(EngenheiroPoco engenheiroPoco)
		{
			await _engenheiroRepository.Add(engenheiroPoco);
		}

		public async Task<List<EngenheiroPoco>> GetAll()
		{

			var engenheiros = await _engenheiroRepository.GetAll();
			return engenheiros;

		}

		public async Task<EngenheiroPoco> GetEngenheiro(int idEngenheiro)
		{

			var engenheiro = await _engenheiroRepository.GetEntityById(idEngenheiro);

			if (engenheiro == null)
				throw new EntityNotFound("Engenheiro não encontrado");


			return engenheiro;

		}

		public async Task<EngenheiroPoco> GetEngenheiroByDocument(string document)
		{
			var engenheiro = await _engenheiroRepository.GetByExpression(x => x.RG == document || x.CREA == document);

			if (!engenheiro.Any())
				throw new EntityNotFound("Engenheiro não encontrado");


			return engenheiro.First();
		}
	}
}
