using GyF_Api_Challenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace GyF_Api_Challenge.Extensions
{
    public static class ServiceProviderExtentesions
    {

        public static void AddAuthenticationCustom(this ServiceProvider services)
        {

        }

        public static void AddLoggingCustom(this IServiceCollection services,IConfiguration configuration)
        {
            var log = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console()
                .Enrich.FromLogContext()
                .CreateLogger();

         //   services.AddLogging(log);
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<GyFContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
