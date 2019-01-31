using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trackr.Api.Model.Repositories;
using Trackr.Api.ViewModels;

namespace Trackr.Api.Managers
{
    /// <inheritdoc />
    public class StatsManager : IStatsManager
    {
        private readonly ChampionshipRepository _championshipRepository;
        private readonly EventRepository _eventRepository;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        /// <param name="championshipRepository"></param>
        /// <param name="eventRepository"></param>
        public StatsManager(ChampionshipRepository championshipRepository, EventRepository eventRepository)
        {
            _championshipRepository = championshipRepository ?? throw new ArgumentNullException(nameof(championshipRepository));
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        /// <inheritdoc />
        public StatsViewModel GetStats()
        {
            return new StatsViewModel
            {
                ChampionshipCount = _championshipRepository.Count(),
                EventCount = _eventRepository.Count(),
                DriverCount = 0,
                SessionCount = 0
            };
        }
    }
}