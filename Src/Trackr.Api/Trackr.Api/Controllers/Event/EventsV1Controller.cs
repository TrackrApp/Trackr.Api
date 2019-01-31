using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trackr.Api.Managers;
using Trackr.Api.Shared.Domain;
using Trackr.Api.ViewModels;

namespace Trackr.Api.Controllers.Event
{
    /// <summary>
    /// Event controller.
    /// </summary>
    [Route("event/v1", Name = "Event V1")]
    public class EventV1Controller : Controller
    {
        private readonly IEventManager _eventManager;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        /// <param name="eventManager"></param>
        public EventV1Controller(IEventManager eventManager)
        {
            _eventManager = eventManager ?? throw new ArgumentNullException(nameof(eventManager));
        }

        /// <summary>
        /// Get all Events for a Championship.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /event/v1/championship/1
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("championship/{championshipId}")]
        public IActionResult AllForChampionship(int championshipId)
        {
            try
            {
                var events = _eventManager.GetAllForChampionship(championshipId);

                if (events?.Any() == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(events);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get a specific Event.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /event/v1/1
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var evt = _eventManager.Get(id);

                if (evt == null)
                {
                    return NotFound();
                }
                else
                {
                    // Cast the event entity to the View Model, and return the Header image as base64 string.
                    var eventVm = evt as EventViewModel;

                    if (evt.HeaderImage != null)
                    {
                        eventVm.HeaderImage = Convert.ToBase64String(evt.HeaderImage);
                    }

                    return Ok(evt);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new Event.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /event/v1/{championshipId}
        /// 
        /// </remarks>
        /// <param name="entity">The entity from the request body.</param>
        /// <param name="championshipId">The id of the championship the Event is for.</param>
        /// <returns></returns>
        [HttpPost("{championshipId}")]
        public async Task<IActionResult> AddAsync([FromBody] EventEntity entity, int championshipId)
        {
            try
            {
                await _eventManager.AddAsync(championshipId, entity).ConfigureAwait(false);

                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}