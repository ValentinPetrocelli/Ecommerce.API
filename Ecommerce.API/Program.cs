using Ecommerce.API.Configurations;
using Ecommerce.Infrastructure.Persistence;
using Hellang.Middleware.ProblemDetails;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;
IServiceCollection services = builder.Services;

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

ProblemDetailsConfiguration.AddProblemDetails(services);
JwtConfiguration.AddAuthentication(config, services);
CorsConfiguration.AddCors(services);
ServicesConfiguration.AddApplicationServices(services);
ServicesConfiguration.AddInfrastructureServices(services);
SwaggerConfiguration.AddSwagger(services);

services.AddControllers();

var app = builder.Build();

app.UseProblemDetails();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.UseHttpsRedirection();

app.Run();
