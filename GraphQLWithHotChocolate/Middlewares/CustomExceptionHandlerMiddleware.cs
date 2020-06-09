using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GraphQLWithHotChocolate.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                try
                {
                    _logger.LogError(ex, ex.Message);

                    httpContext.Response.Clear();
                    httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    httpContext.Response.Headers["Content-Type"] = "application/json";
                    await httpContext.Response.WriteAsync("OK");

                    return;
                }
                catch (Exception ex2)
                {
                    _logger.LogError(ex2, ex2.Message);
                    throw;
                }
            }
        }
    }
}
