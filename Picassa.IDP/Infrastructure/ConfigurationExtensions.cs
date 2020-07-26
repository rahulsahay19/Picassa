using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Picassa.IDP.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
    }
}
