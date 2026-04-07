using TrabalhoDevOpsInfnet.Application.UseCases.Calculo.CalcularJurosCompostos;
using TrabalhoDevOpsInfnet.Data;
using TrabalhoDevOpsInfnet.Domain.SeedWork;

namespace TrabalhoDevOpsInfnet.API.Configurations
{
    public static class UseCasesConfiguration
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CalcularJurosCompostos).Assembly));
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
