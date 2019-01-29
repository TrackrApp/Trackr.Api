using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trackr.Api.Model.Repositories;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Managers
{
    /// <inheritdoc />
    public class EventManager: IEventManager
    {
        private readonly EventRepository _eventRepository;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        public EventManager(EventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        /// <inheritdoc />
        public List<EventEntity> GetAllForChampionship(int championshipId)
        {
            return _eventRepository.GetAllForChampionship(championshipId);
        }

        /// <inheritdoc />
        public EventEntity Get(int id)
        {
            return _eventRepository.Get(id);
        }

        /// <inheritdoc />
        public async Task AddAsync(int championshipId, EventEntity entity)
        {
            await _eventRepository.AddAsync(championshipId, entity).ConfigureAwait(false);
        }
    }
}