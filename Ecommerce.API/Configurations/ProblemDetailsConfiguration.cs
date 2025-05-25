using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Configurations
{
    public static class ProblemDetailsConfiguration
    {
        public static void AddProblemDetails(IServiceCollection services)
        {
            services.AddProblemDetails(options =>
            {
                options.Map<ApplicationException>(ex => new ProblemDetails
                {
                    Title = "Application error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });

                options.Map<UnauthorizedAccessException>(ex => new ProblemDetails
                {
                    Title = "Unauthorized Access",
                    Detail = ex.Message,
                    Status = StatusCodes.Status401Unauthorized
                });

                options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);
                options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
            });
        }
    }
}
