using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Trackr.Api.Middleware
{
    /// <summary>
    /// Custom middleware to check wether the Api Key used in requests are valid.
    /// </summary>
    public class ApiKeyValidatorMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="next"></param>
        public ApiKeyValidatorMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Invoke the request.
        /// </summary>
        /// <param name="context">The request.</param>
        /// <returns>The result of the request.</returns>
        public async Task Invoke(HttpContext context)
        {
            // First check wether the Api Key is sent. If not, return an error.
            if (!context.Request.Headers.Keys.Contains("api-key"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Api Key is missing!").ConfigureAwait(false);
                return;
            }
            else
            {
                // todo: check in repository wether the key exists and is valid.

                // If the key is invalid, return Unauthorized.
                if (true == false)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Invalid Api Key!").ConfigureAwait(false);
                    return;
                }

                // All is good, continue invoking the request.
                await _next.Invoke(context).ConfigureAwait(false);
            }
        }
    }
}