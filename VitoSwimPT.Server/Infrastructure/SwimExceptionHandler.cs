using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace VitoSwimPT.Server.Infrastructure
{
    public class SwimExceptionHandler: IExceptionHandler
    {
        private readonly Serilog.ILogger _logger;

        public SwimExceptionHandler(Serilog.ILogger logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //Log exception
            //logger.LogError(exception, "An unhandled exception occurred.");

            _logger.Error(exception, "An unhandled exception occurred.");
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred",
                Status = StatusCodes.Status400BadRequest,
                Detail = exception.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
