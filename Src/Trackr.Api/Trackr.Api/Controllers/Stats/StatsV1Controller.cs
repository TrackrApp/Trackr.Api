using System;
using Microsoft.AspNetCore.Mvc;
using Trackr.Api.Managers;

namespace Trackr.Api.Controllers.Stats
{
    /// <summary>
    /// Event controller.
    /// </summary>
    [Route("stats/v1", Name = "Stats V1")]
    public class StatsV1Controller : Controller
    {
        private readonly IStatsManager _statsManager;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        /// <param name="statsManager"></param>
        public StatsV1Controller(IStatsManager statsManager)
        {
            _statsManager = statsManager ?? throw new ArgumentNullException(nameof(statsManager));
        }

        /// <summary>
        /// Get the stats.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /stats/v1/
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var stats = _statsManager.GetStats();

                if (stats == null)
                {
                    return NotFound();
                }
                else
                {                   
                    return Ok(stats);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}