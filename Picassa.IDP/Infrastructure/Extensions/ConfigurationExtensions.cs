namespace Picassa.IDP.Infrastructure.Extensions
{
    using Microsoft.Extensions.Configuration;
    public static class ConfigurationExtensions
    {
        public static string GetConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
    }
}
