using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trackr.Api.Managers;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.Controllers.Championship
{
    /// <summary>
    /// Championship controller.
    /// </summary>
    [Route("championship/v1", Name = "Championship V1")]
    public class ChampionshipV1Controller : Controller
    {
        private readonly IChampionshipManager _championshipManager;

        /// <summary>
        /// DI-constructor.
        /// </summary>
        /// <param name="championshipManager"></param>
        public ChampionshipV1Controller(IChampionshipManager championshipManager)
        {
            _championshipManager = championshipManager ?? throw new ArgumentNullException(nameof(championshipManager));
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
        /// Get a specific Championship.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /championship/v1/{id}
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
                    // A Championship was found, return it.
                    return Ok(championship);
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