using GyF_Api_Challenge.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GyF_Api_Challenge
{
    public class InitializeDataBaseHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public InitializeDataBaseHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<GyFContext>();

                dbContext.Database.EnsureCreated();

                if (dbContext.Clientes.Any())
                {
                    dbContext.Clientes.Add(new Core.Models.Cliente("Carlos Javier Bustos"));
                    dbContext.Clientes.Add(new Core.Models.Cliente("Juan Gomez"));
                    dbContext.Clientes.Add(new Core.Models.Cliente("Natalia Benitez"));

                    dbContext.SaveChanges();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
