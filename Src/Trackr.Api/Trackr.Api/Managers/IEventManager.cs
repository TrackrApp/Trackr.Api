using System.Collections.Generic;
using System.Threading.Tasks;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Managers
{
    /// <summary>
    /// Manager interface for anything Event related.
    /// </summary>
    public interface IEventManager
    {
        /// <summary>
        /// Get all Events for a given Championship.
        /// </summary>
        /// <param name="championshipId">The id of the Championship.</param>
        /// <returns>A collection of Events.</returns>
        List<EventEntity> GetAllForChampionship(int championshipId);

        /// <summary>
        /// Get a specific Event.
        /// </summary>
        /// <param name="id">The id of the requested Event.</param>
        /// <returns></returns>
        EventEntity Get(int id);

        /// <summary>
        /// Add the given Event entity to storage.
        /// </summary>
        /// <param name="championshipId">The id of the Championship where the Event is for.</param>
        /// <param name="entity">The entity to add.</param>
        /// <returns></returns>
        Task AddAsync(int championshipId, EventEntity entity);
    }
}