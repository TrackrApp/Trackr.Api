using System.Collections.Generic;
using System.Threading.Tasks;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Managers
{
    /// <summary>
    /// Manager interface for anything Session related.
    /// </summary>
    public interface ISessionManager
    {
        /// <summary>
        /// Get all Sessions for a given Event.
        /// </summary>
        /// <param name="eventId">The id of the Event.</param>
        /// <returns>A collection of Sessions.</returns>
        List<SessionEntity> GetAllForEvent(int eventId);

        /// <summary>
        /// Get a specific Session.
        /// </summary>
        /// <param name="id">The id of the requested Session.</param>
        /// <returns></returns>
        SessionEntity Get(int id);

        /// <summary>
        /// Add the given Session entity to storage.
        /// </summary>
        /// <param name="eventId">The id of the Event where the Session is for.</param>
        /// <param name="entity">The entity to add.</param>
        /// <returns></returns>
        Task AddAsync(int eventId, SessionEntity entity);
    }
}