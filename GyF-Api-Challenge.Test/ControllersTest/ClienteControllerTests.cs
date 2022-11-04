using GyF_Api_Challenge.Controllers;
using GyF_Api_Challenge.Core.Models;
using GyF_Api_Challenge.Data;
using GyF_Api_Challenge.Test.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Test.ControllersTest
{
    public class ClienteControllerTests
    {
        GyFContext dbContext = null;

        [SetUp]
        public void Setup()
        {
            dbContext = TestHelper.InitializeDatabase();
        }

        [Test]
        public void Deberia_devolver_status_code_200_al_crear_cliente()
        {
            //Arrange
            var clienteService = TestHelper.GetClienteService(dbContext);

            var clienteController = new ClienteController(null, clienteService, TestHelper.GetMapper());

            // Act
            var result = clienteController.Create(new Api.Models.BaseClienteModel { FechaNacimiento = DateTime.Today, Nombre = "Carlos" });

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public  void Deberia_devolver_status_code_200_al_actualizar_cliente()
        {
            //Arrange
            var clienteService = TestHelper.GetClienteService(dbContext);

            var cliente = new Cliente
            {
                Nombre = "Carlos Rodriguez",
                FechaNacimiento = DateTime.Today,
                Genero = Core.Enums.GeneroEnum.Femenino
            };

            dbContext.Add(cliente);
            dbContext.SaveChanges();

            var clienteController = new ClienteController(null, clienteService, TestHelper.GetMapper());

            // Act
            var result = clienteController.UpdateAsync(cliente.Id, new Api.Models.BaseClienteModel { FechaNacimiento = DateTime.Today, Nombre = "Carlos", Genero = Core.Enums.GeneroEnum.NoBinario }).GetAwaiter().GetResult();

            // Assert
            Assert.That(result, Is.TypeOf<OkResult>());

        }

        [Test]
        public void Deberia_devolver_status_code_200_al_dar_de_baja_un_cliente()
        {
            //Arrange
            var clienteService = TestHelper.GetClienteService(dbContext);

            var cliente = new Cliente
            {
                Nombre = "Carlos Rodriguez",
                FechaNacimiento = DateTime.Today,
                Genero = Core.Enums.GeneroEnum.Femenino,
                EstaActivo=true
            };

            dbContext.Add(cliente);
            dbContext.SaveChanges();
 
            var clienteController = new ClienteController(null, clienteService, TestHelper.GetMapper());

            // Act
            var result = clienteController.Delete(cliente.Id).GetAwaiter().GetResult();

            // Assert
            Assert.That(result, Is.TypeOf<OkResult>());

        }

        [Test]
        public void Deberia_devolver_status_code_200_al_listar_clientes()
        {
            //Arrange
            var clienteService = TestHelper.GetClienteService(dbContext);

            var clienteController = new ClienteController(null, clienteService, TestHelper.GetMapper());

            // Act
            var result = clienteController.ListAsync().GetAwaiter().GetResult();

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Deberia_devolver_status_code_200_al_listar_clientes_activos()
        {
            //Arrange
            var clienteService = TestHelper.GetClienteService(dbContext);

            var clienteController = new ClienteController(null, clienteService, TestHelper.GetMapper());

            // Act
            var result = clienteController.ListActivesAsync().GetAwaiter().GetResult();

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}
