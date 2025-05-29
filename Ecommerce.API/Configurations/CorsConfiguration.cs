namespace Ecommerce.API.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCors(IServiceCollection services)
        {
            string allowedOrigin = "http://localhost:5173";

            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins(allowedOrigin)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
        }
    }
}
