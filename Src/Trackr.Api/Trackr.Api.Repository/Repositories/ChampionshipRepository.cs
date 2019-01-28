using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trackr.Api.Model.Helpers;
using Trackr.Api.Model.Storage;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Repositories
{
    /// <inheritdoc />
    public class ChampionshipRepository : IRepository<ChampionshipEntity>
    {
        private TrackrApiDbContext _dbContext;

        public ChampionshipRepository(TrackrApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <inheritdoc />
        public List<ChampionshipEntity> GetAll()
        {
            // Retrieve all Championships.
            var all = _dbContext.Championships.ToList();
            
            // Convert them to entity and return the result.
            return all.ToEntity();
        }

        /// <inheritdoc />
        public ChampionshipEntity Get(int id)
        {
            // Find a match for the given id.
            var match = _dbContext.Championships.FirstOrDefault(c => c.Id == id);

            return match.ToEntity();
        }

        /// <inheritdoc />
        public List<ChampionshipEntity> Find(string query)
        {
            // If the input is empty, just return an empty list.
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<ChampionshipEntity>();
            }

            var matches = _dbContext.Championships.Where(c => c.Name.Contains(query)).ToList();

            return matches.ToEntity();
        }

        /// <inheritdoc />
        public async Task<int> AddAsync(ChampionshipEntity entity)
        {
            var state = entity.ToState();

            await _dbContext.Championships.AddAsync(state).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return state.Id;
        }
    }
}