using TrabalhoDevOpsInfnet.API.Filters;
using TrabalhoDevOpsInfnet.API.JsonPolicies;

namespace TrabalhoDevOpsInfnet.API.Configurations
{
    public static class ControllerConfiguration
    {
        public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
                options.Filters.Add(typeof(APIGlobalExceptionFilter)))
                    .AddJsonOptions(x => x.JsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCasePolicy());
            services.AddDocumentation();
            return services;
        }

        private static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static WebApplication UseDocumentation(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }
    }
}
