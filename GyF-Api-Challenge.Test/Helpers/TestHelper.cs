using AutoMapper;
using GyF_Api.Challenge.Service;
using GyF_Api_Challenge.Data.Interfaces;
using GyF_Api_Challenge.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyF_Api_Challenge.Api.MappingProfiles;

namespace GyF_Api_Challenge.Test.Helpers
{
    public static class TestHelper
    {
        public static GyFContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<GyFContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new GyFContext(options);
            databaseContext.Database.EnsureCreated();


            return databaseContext;
        }

        public static IMapper GetMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = mockMapper.CreateMapper();

            return mapper;
        }

        public static ClienteService GetClienteService(GyFContext dbcontext)
        {
            //Arrange
            IUnitOfWork unitOfWork = new UnitOfWork(dbcontext);

            return new ClienteService(unitOfWork, GetMapper());
        }

        public static GyFContext InitializeDatabase()
        {
            var dbContext = GetDatabaseContext();

            dbContext.Database.EnsureCreated();

            if (!dbContext.Clientes.Any())
            {
                dbContext.Clientes.Add(new Core.Models.Cliente
                {
                    Cuil = "23-29138541-9",
                    Telefono = "11 6610 3317",
                    EstaActivo = true,
                    FechaNacimiento = new DateTime(1981, 10, 10),
                    Nombre = "Carlos Javier Bustos",
                    Genero = Core.Enums.GeneroEnum.Masculino
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

            return dbContext;
        }
    }
}
