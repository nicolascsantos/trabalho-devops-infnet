using Microsoft.EntityFrameworkCore;
using TrabalhoDevOpsInfnet.Data;

namespace TrabalhoDevOpsInfnet.API.Configurations
{
    public static class ConnectionsConfiguration
    {
        public static IServiceCollection AddAppConnections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbConnection(configuration);
            return services;
        }

        private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("CatalogDb") ?? string.Empty;
            services.AddDbContext<TrabalhoDevOpsDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
