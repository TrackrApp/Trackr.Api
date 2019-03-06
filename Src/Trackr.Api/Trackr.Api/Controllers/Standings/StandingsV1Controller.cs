using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Trackr.Api.Managers;
using Trackr.Api.Mappers;

namespace Trackr.Api.Controllers.Event
{
    /// <summary>
    /// Standings controller.
    /// </summary>
    [Route("standings/v1", Name = "Standings V1")]
    public class StandingsV1Controller : Controller
    {
        private readonly IEventManager _eventManager;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        /// <param name="eventManager"></param>
        public StandingsV1Controller(IEventManager eventManager)
        {
            _eventManager = eventManager ?? throw new ArgumentNullException(nameof(eventManager));
        }

        /// <summary>
        /// Get the standings for a Championshp.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /standings/v1/championship/1
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("championship/{championshipId}")]
        public IActionResult AllForChampionship(int championshipId)
        {
            try
            {
                // Get all the events for the championship.
                var allEvents = _eventManager.GetAllForChampionship(championshipId);

                // Gather the standings based on all the race results.
                var standings = ChampionshipMapper.RetrieveStandingsFromChampionship(allEvents).ToList();

                if (standings?.Any() == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(standings);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}