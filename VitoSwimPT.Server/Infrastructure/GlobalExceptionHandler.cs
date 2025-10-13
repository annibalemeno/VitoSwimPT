using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace VitoSwimPT.Server.Infrastructure
{
    internal sealed class GlobalExceptionHandler(IProblemDetailsService problemDetailsService, Serilog.ILogger logger)
        : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.Error(exception, "An error has occured");

            httpContext.Response.StatusCode = exception switch
            {
                ApplicationException => StatusCodes.Status400BadRequest,
               _=> StatusCodes.Status500InternalServerError
            };


            //await httpContext.Response.WriteAsJsonAsync(
            //    new ProblemDetails
            //    {
            //        Type = exception.GetType().Name,
            //        Title = "An error has occured",
            //        Detail = exception.Message
            //    });
            //return true;

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails
                {
                    Type = exception.GetType().Name,
                    Title = "An error has occured",
                    Detail = exception.Message
                }
            });
        }
    }
}
