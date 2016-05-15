using System.Data.Entity;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Bootstrap
{
    public static class BootstrapConfig
    {
        private const string RepositoryNamespace = "DataAccess.Repositories";
        private const string ServiceNamespace = "Domain.Services";

        public static void RegisterApplicationServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            // DbContext
            services.AddScoped<DbContext>(x => new ApplicationContext(configuration["Data:ApplicationContext:ConnectionString"]));

            // Repositories
            var repositoryAssembly = typeof(BootstrapRepository).Assembly;
            var repositoryRegistrations = repositoryAssembly
                .GetExportedTypes()
                .Where(type => type.Namespace == RepositoryNamespace && type.GetInterfaces().Any())
                .Select(type => new
                {
                    Interface = type.GetInterfaces().Single(),
                    Implementation = type
                });
            foreach (var reg in repositoryRegistrations)
            {
                services.AddTransient(reg.Interface, reg.Implementation);
            }

            // Services
            var serviceAssembly = typeof(BootstrapService).Assembly;
            var serviceRegistrations = serviceAssembly
                .GetExportedTypes()
                .Where(type => type.Namespace == ServiceNamespace && type.GetInterfaces().Any())
                .Select(type => new
                {
                    Interface = type.GetInterfaces().Single(),
                    Implementation = type
                });
            foreach (var reg in serviceRegistrations)
            {
                services.AddTransient(reg.Interface, reg.Implementation);
            }
        }
    }
}
