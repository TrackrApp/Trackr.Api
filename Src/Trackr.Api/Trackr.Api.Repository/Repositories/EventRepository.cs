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
    public class EventRepository
    {
        private TrackrApiDbContext _dbContext;

        public EventRepository(TrackrApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public int Count()
        {
            return _dbContext.Events.Count();
        }

        public List<EventEntity> GetAllForChampionship(int championshipId)
        {
            // Retrieve all Events for a Championship.
            var all = _dbContext.Events
                .Include(r => r.Sessions)                
                    .ThenInclude(s => s.Results)
                .Where(r => r.ChampionshipId == championshipId).ToList();

            // Convert them to entity and return the result.
            return all.ToEntity();
        }

        public EventEntity Get(int id)
        {
            // Find a match for the given id.
            var match = _dbContext.Events
                .Include(r => r.Sessions)
                    .ThenInclude(s => s.Results)
                .FirstOrDefault(c => c.Id == id);

            // If no match was found, return null.
            if (match == null)
            {
                return null;
            }

            return match.ToEntity();
        }

        public async Task<int> AddAsync(int championshipId, EventEntity entity)
        {
            var state = entity.ToState();

            // Try to retrieve the Championship to which the Event should be added.
            var championship = await _dbContext.Championships.FirstOrDefaultAsync(c => c.Id == championshipId).ConfigureAwait(false);

            // Check wether the Championship exists. If not, return an error code.
            if (championship == null)
            {
                return -1;
            }

            // Add the event to the Championship.
            championship.Events.Add(state);
            
            // Save the changes.
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            // Return the id of the created event.
            return state.Id;
        }
    }
}