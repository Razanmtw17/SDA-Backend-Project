using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SDA_Backend_Project.src.Middlewares
{
    public class LoggingMiddleware
    {
         protected readonly RequestDelegate _next;
        protected readonly ILogger<LoggingMiddleware> _logger;
        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        //method to print the request and response info
        public async Task InvokeAsync(HttpContext context){

            //request log:
            _logger.LogInformation($"Incoming request: {context.Request.Method} , {context.Request.Path}");
            var stopWatch = Stopwatch.StartNew();
            await _next(context);
            stopWatch.Stop();
            //response log: 
            _logger.LogInformation($"Outgoing request: {context.Response.StatusCode} takes {stopWatch.ElapsedMilliseconds}ms"); 
        }
    }
}
