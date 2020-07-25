using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Picassa.IDP.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Picassa.IDP.Infrastructure;

namespace Picassa.IDP
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) => _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        => services.AddDbContext<PicassaDbContext>(options =>
                    options.UseSqlServer(
                        _configuration.GetConnectionString()))
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(_configuration))
                .AddControllers();



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
            }

            app.UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                    .UseAuthentication()
                    .UseAuthorization()
                .UseEndpoints(
                    endpoints =>
                    {
                        endpoints.MapControllers();
                    })
                .ApplyMigrations();
        }
    }
}
