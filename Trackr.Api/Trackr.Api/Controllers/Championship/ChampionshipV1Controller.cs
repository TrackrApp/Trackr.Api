using Microsoft.AspNetCore.Mvc;

namespace Trackr.Api.Controllers.Championship
{
    /// <summary>
    /// Championship controller.
    /// </summary>
    [Route("championship/v1")]
    public class ChampionshipV1Controller : Controller
    {
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
        [HttpGet]
        public IActionResult All()
        {
            return View();
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
        [HttpGet]
        public IActionResult Get(int id)
        {
            return View();
        }

        /// <summary>
        /// Create a Championship.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /championship/v1
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] int temp)
        {
            return Created($"/championship/v1/{temp}", temp);
        }

        /// <summary>
        /// Create a Championship.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /championship/v1/{id}
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(int id, [FromBody] int temp)
        {
            return Created($"/championship/v1/{temp}", temp);
        }

        /// <summary>
        /// Delete a Championship.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /championship/v1/{id}
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Accepted();
        }
    }
}