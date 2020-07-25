using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Picassa.IDP.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");

        public static ApplicationSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(applicationSettingsConfig);
            return applicationSettingsConfig.Get<ApplicationSettings>();
        }
    }
}
