using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trackr.Api.Model.Repositories;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Managers
{
    /// <inheritdoc />
    public class ChampionshipManager : IChampionshipManager
    {
        private readonly ChampionshipRepository _championshipRepository;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        public ChampionshipManager(ChampionshipRepository championshipRepository)
        {
            _championshipRepository = championshipRepository ?? throw new ArgumentNullException(nameof(championshipRepository));
        }

        /// <inheritdoc />
        public List<ChampionshipEntity> GetAll()
        {
            return _championshipRepository.GetAll();
        }

        /// <inheritdoc />
        public List<ChampionshipEntity> Find(string query)
        {
            return _championshipRepository.Find(query);
        }

        /// <inheritdoc />
        public ChampionshipEntity Get(int id)
        {
            return _championshipRepository.Get(id);
        }

        /// <inheritdoc />
        public async Task AddAsync(ChampionshipEntity entity)
        {
            await _championshipRepository.AddAsync(entity).ConfigureAwait(false);
        }
    }
}