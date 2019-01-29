using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trackr.Api.Model.Helpers;
using Trackr.Api.Model.Storage;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Model.Repositories
{
    /// <inheritdoc />
    public class EventRepository
    {
        private TrackrApiDbContext _dbContext;

        public EventRepository(TrackrApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <inheritdoc />
        public List<EventEntity> GetAllForChampionship(int championshipId)
        {
            // Retrieve all Championships.
            var all = _dbContext.Events
                .Include(r => r.Sessions)                
                    .ThenInclude(s => s.Results)
                .Where(r => r.ChampionshipId == championshipId).ToList();

            // Convert them to entity and return the result.
            return all.ToEntity();
        }

        /// <inheritdoc />
        public EventEntity Get(int id)
        {
            // Find a match for the given id.
            var match = _dbContext.Events.FirstOrDefault(c => c.Id == id);

            return match.ToEntity();
        }

        /// <inheritdoc />
        public async Task<int> AddAsync(EventEntity entity)
        {
            var state = entity.ToState();

            await _dbContext.Events.AddAsync(state).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return state.Id;
        }
    }
}