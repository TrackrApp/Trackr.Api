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
    public class SessionRepository
    {
        private TrackrApiDbContext _dbContext;

        public SessionRepository(TrackrApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public int Count()
        {
            return _dbContext.Sessions.Count();
        }

        public List<SessionEntity> GetAllForEvent(int eventId)
        {
            // Retrieve all Sessions for an Event.
            var all = _dbContext.Sessions                                
                .Include(s => s.Results)
                .Where(s => s.EventId == eventId).ToList();

            // Convert them to entity and return the result.
            return all.ToEntity();
        }

        public SessionEntity Get(int id)
        {
            // Find a match for the given id.
            var match = _dbContext.Sessions                
                .Include(s => s.Results)
                .FirstOrDefault(s => s.Id == id);

            // If no match was found, return null.
            if (match == null)
            {
                return null;
            }

            return match.ToEntity();
        }

        public async Task<int> AddAsync(int eventId, SessionEntity entity)
        {
            var state = entity.ToState();

            // Try to retrieve the Event to which the Session should be added.
            var evt = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId).ConfigureAwait(false);

            // Check wether the Event exists. If not, return an error code.
            if (evt == null)
            {
                return -1;
            }

            // Add the Session to the Event.
            evt.Sessions.Add(state);
            
            // Save the changes.
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            // Return the id of the created event.
            return state.Id;
        }
    }
}