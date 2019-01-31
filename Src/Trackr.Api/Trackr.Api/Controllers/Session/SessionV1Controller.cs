using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trackr.Api.Managers;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Controllers.Event
{
    /// <summary>
    /// Session controller.
    /// </summary>
    [Route("session/v1", Name = "Session V1")]
    public class SessionV1Controller : Controller
    {
        private readonly ISessionManager _sessionManager;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        /// <param name="sessionManager"></param>
        public SessionV1Controller(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager ?? throw new ArgumentNullException(nameof(sessionManager));
        }

        /// <summary>
        /// Get all Session for an Event.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /sessions/v1/event/1
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("event/{eventId}")]
        public IActionResult AllForChampionship(int sessionId)
        {
            try
            {
                var sessions = _sessionManager.GetAllForEvent(sessionId);

                if (sessions?.Any() == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(sessions);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get a specific Session.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /session/v1/1
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var session = _sessionManager.Get(id);

                if (session == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(session);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new Session.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /session/v1/{eventId}
        /// 
        /// </remarks>
        /// <param name="entity">The entity from the request body.</param>
        /// <param name="eventId">The id of the Event the Session is for.</param>
        /// <returns></returns>
        [HttpPost("{eventId}")]
        public async Task<IActionResult> AddAsync([FromBody] SessionEntity entity, int eventId)
        {
            try
            {
                await _sessionManager.AddAsync(eventId, entity).ConfigureAwait(false);

                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}