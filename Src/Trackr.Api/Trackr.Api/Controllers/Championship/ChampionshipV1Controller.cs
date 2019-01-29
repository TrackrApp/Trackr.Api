using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trackr.Api.Managers;
using Trackr.Api.Mappers;
using Trackr.Api.Shared.Domain;
using Trackr.Api.ViewModels;

namespace Trackr.Api.Controllers.Championship
{
    /// <summary>
    /// Championship controller.
    /// </summary>
    [Route("championship/v1", Name = "Championship V1")]
    public class ChampionshipV1Controller : Controller
    {
        private readonly IChampionshipManager _championshipManager;
        private readonly IEventManager _eventManager;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        /// <param name="championshipManager"></param>
        /// <param name="eventManager"></param>
        public ChampionshipV1Controller(
            IChampionshipManager championshipManager,
            IEventManager eventManager)
        {
            _championshipManager = championshipManager ?? throw new ArgumentNullException(nameof(championshipManager));
            _eventManager = eventManager ?? throw new ArgumentNullException(nameof(eventManager));
        }

        /// <summary>
        /// Get all Championships.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /championship/v1
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult All()
        {
            return View();
        }

        /// <summary>
        /// Find a Championship
        /// </summary>
        /// <param name="query">The query used to match Championships.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /championship/v1/find?query=OTKC
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("find")]
        public IActionResult Find([FromQuery] string query)
        {
            try
            {
                // Find Championships based on the input.
                var result = _championshipManager.Find(query);

                // Searching was succesful, return the result.
                return Ok(result);
            }
            catch (Exception ex)
            {
                // An error occurred.
                return BadRequest();
            }
        }

        /// <summary>
        /// Get a specific Championship overview.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /championship/v1/{id}
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetOverview(int id)
        {
            try
            {
                // Get a Championship by id.
                var championship = _championshipManager.Get(id);

                // If the retrieved Championship is null, it does not exist. Return status code accordingly.
                if (championship == null)
                {
                    return NotFound();
                }
                else
                {
                    // Get all the events for the championship.
                    var allEvents = _eventManager.GetAllForChampionship(id);

                    // Find the last session result from the latest Event. 
                    var lastRaceEvent = allEvents.FindLast(e => e.Sessions.FindLast(s => s.Results.Count > 0) != null);
                    lastRaceEvent.Sessions = new List<SessionEntity> {
                        lastRaceEvent.Sessions.Where(s => s.Results.Count > 0).First()
                    };

                    // Overwrite the result list with only the top 3 of the results.
                    lastRaceEvent.Sessions.FirstOrDefault().Results = lastRaceEvent.Sessions.FirstOrDefault().Results.Take(3).ToList();

                    // Gather the standings based on all the race results, and take the top 3.
                    var standings = ChampionshipMapper.RetrieveStandingsFromChampionship(allEvents).Take(3).ToList();

                    // Return the enriched championship.
                    return Ok(new ChampionshipOverviewViewModel
                    {
                        Id = championship.Id,
                        Name = championship.Name,
                        Description = championship.Description,
                        LastResult = lastRaceEvent,
                        Standings = standings
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new Championship.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /championship/v1/{id}
        /// 
        /// </remarks>
        /// <param name="entity">The entity from the request body.</param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> AddAsync([FromBody] ChampionshipEntity entity)
        {
            try
            {
                await _championshipManager.AddAsync(entity).ConfigureAwait(false);

                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}