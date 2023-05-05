
using API._Repositories.Interfaces;
using API._Repositories.Repositories;
using API._Services.Interfaces;
using API._Services.Services;

namespace API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //Repositories
            services.AddScoped<INhapXuatRepository, NhapXuatRepository>();

            // Add Service
            services.AddScoped<IHomeService, HomeService>();
        }
    }
}