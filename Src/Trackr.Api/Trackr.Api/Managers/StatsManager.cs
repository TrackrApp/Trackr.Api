using System;
using Trackr.Api.Model.Repositories;
using Trackr.Api.ViewModels;

namespace Trackr.Api.Managers
{
    /// <inheritdoc />
    public class StatsManager : IStatsManager
    {
        private readonly ChampionshipRepository _championshipRepository;
        private readonly EventRepository _eventRepository;
        private readonly SessionRepository _sessionRepository;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        /// <param name="championshipRepository"></param>
        /// <param name="eventRepository"></param>
        /// <param name="sessionRepository">?</param>
        public StatsManager(
            ChampionshipRepository championshipRepository,
            EventRepository eventRepository,
            SessionRepository sessionRepository)
        {
            _championshipRepository = championshipRepository ?? throw new ArgumentNullException(nameof(championshipRepository));
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _sessionRepository = sessionRepository ?? throw new ArgumentNullException(nameof(sessionRepository));
        }

        /// <inheritdoc />
        public StatsViewModel GetStats()
        {
            return new StatsViewModel
            {
                ChampionshipCount = _championshipRepository.Count(),
                EventCount = _eventRepository.Count(),
                DriverCount = 0,
                SessionCount = _sessionRepository.Count()
            };
        }
    }
}