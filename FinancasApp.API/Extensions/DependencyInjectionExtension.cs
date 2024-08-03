using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Services;
using FinancasApp.Infra.Data.Repositories;

namespace FinancasApp.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IContaDomainService, ContaDomainService>();
            services.AddTransient<IContaRepository, ContaRepository>();

            return services;
        }
    }
}
