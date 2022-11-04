using GyF_Api_Challenge.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Api
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

                if (!dbContext.Clientes.Any())
                {
                    dbContext.Clientes.Add(new Core.Models.Cliente
                    {
                        Cuil="23-29138541-9",
                        Telefono="11 6610 3317",
                        EstaActivo=true,
                        FechaNacimiento= new DateTime(1981,10,10),
                        Nombre="Carlos Javier Bustos",
                        Genero=Core.Enums.GeneroEnum.Masculino
                    });
                    dbContext.Clientes.Add(new Core.Models.Cliente
                    {
                        Cuil = "23-29138123-1",
                        Telefono = "11 5555 66666",
                        EstaActivo = false,
                        FechaNacimiento = new DateTime(1980, 01, 01),
                        Nombre = "Nombre persona de baja",
                        Genero = Core.Enums.GeneroEnum.NoBinario
                    });

                    dbContext.SaveChanges();
                }

                UserManager<IdentityUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                if (!dbContext.Users.Any())
                {
                    var result = await userManager.CreateAsync(new IdentityUser("usuario"), "123456");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
