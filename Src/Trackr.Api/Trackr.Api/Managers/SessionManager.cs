using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trackr.Api.Model.Repositories;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Managers
{
    /// <inheritdoc />
    public class SessionManager: ISessionManager
    {
        private readonly SessionRepository _sessionRepository;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        public SessionManager(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        }        

        /// <inheritdoc />
        public List<SessionEntity> GetAllForEvent(int eventId)
        {
            return _sessionRepository.GetAllForEvent(eventId);
        }

        /// <inheritdoc />
        public SessionEntity Get(int id)
        {
            return _sessionRepository.Get(id);
        }

        /// <inheritdoc />
        public async Task AddAsync(int eventId, SessionEntity entity)
        {
            await _sessionRepository.AddAsync(eventId, entity).ConfigureAwait(false);
        }
    }
}