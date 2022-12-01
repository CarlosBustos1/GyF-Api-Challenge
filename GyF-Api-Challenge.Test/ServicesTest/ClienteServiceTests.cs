using AutoMapper;
using GyF_Api.Challenge.Service;
using GyF_Api_Challenge.Core.Models;
using GyF_Api_Challenge.Data;
using GyF_Api_Challenge.Data.Interfaces;
using GyF_Api_Challenge.Data.Repositories;
using GyF_Api_Challenge.Test.Helpers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Test.ServicesTest
{
    public class ClienteServiceTests
    {
        GyFContext dbContext = null;

        [SetUp]
        public void Setup()
        {
            dbContext = TestHelper.InitializeDatabase();
        }

        [Test]
        public void Deberia_Crear_un_Cliente()
        {

            var clienteService = TestHelper.GetClienteService(dbContext);

            var clienteId = clienteService.Create(new Core.Dtos.BaseClienteDto
            {
                Nombre = "Carlos",
                FechaNacimiento = new DateTime(1981, 10, 10)
            });

            var cliente = dbContext.Clientes.FirstOrDefault(x => x.Id == clienteId);

            Assert.That(cliente != null);

        }

        [Test]
        public void Deberia_Crear_un_Cliente_moq()
        {
            //arrange

            var clienteDto = new Core.Dtos.BaseClienteDto
            {
                Nombre = "Carlos",
                FechaNacimiento = new DateTime(1981, 10, 10)
            };

            var mockSet = new Mock<DbSet<Cliente>>();

            var mockContext = new Mock<GyFContext>();

            Mock<Cliente> cliente = new Mock<Cliente>();
            Mock<UnitOfWork> unitOfWork = new Mock<UnitOfWork>(mockContext.Object);
            Mock<IMapper> mapper = Helpers.TestHelper.MappingData();
            unitOfWork.CallBase = true;
            Mock<UpdatableRepository<Cliente, int>> repository = new Mock<UpdatableRepository<Cliente, int>>(mockContext.Object);

     
            mockContext.Setup(m => m.Clientes).Returns(mockSet.Object).Verifiable();
            unitOfWork.Setup(m => m.Clientes).Returns(repository.Object).Verifiable();
            unitOfWork.Setup(m => m.Clientes.Persist(cliente.Object)).Verifiable();

            //act
            var service = new ClienteService(unitOfWork.Object, mapper.Object);

            service.Create(clienteDto);

            //assert
            unitOfWork.Verify(m => m.SaveChanges(), Times.Once());
            unitOfWork.Verify(m => m.Clientes.Persist(It.IsAny<Cliente>()), Times.Once());
            mockContext.Verify(m=>m.SaveChanges(), Times.Once());
            mockContext.Verify(m => m.Add(It.IsAny<Cliente>()), Times.Once());
            // unitOfWork.VerifyAll();
            //      mockContext.Verify(m => m.Add(It.IsAny<Object>()), Times.Once());



        }

        [Test]
        public void Deberia_actualizar_el_nombre_de_un_cliente()
        {

            var clienteService = TestHelper.GetClienteService(dbContext);

            var clienteNuevo = new Cliente
            {
                Nombre = "Nombre nuevo",
                Cuil = "222222",
                FechaNacimiento = DateTime.Today,
                Genero = Core.Enums.GeneroEnum.Masculino
            };

            dbContext.Clientes.Add(clienteNuevo);

            dbContext.SaveChanges();

            string nombreActualizado = "Nombre actualiado";

            clienteService.UpdateAsync(clienteNuevo.Id, new Core.Dtos.BaseClienteDto
            {
                Nombre = nombreActualizado,
                Cuil = "222222",
                FechaNacimiento = DateTime.Today,
                Genero = Core.Enums.GeneroEnum.Masculino
            }).GetAwaiter().GetResult();

            var clienteLeido = dbContext.Clientes.Find(clienteNuevo.Id);

            Assert.That(clienteLeido.Nombre == nombreActualizado);

        }

        [Test]
        public void Deberia_dar_baja_logica_a_un_cliente()
        {

            var clienteService = TestHelper.GetClienteService(dbContext);

            var clienteId = 1;

            var cliente = dbContext.Clientes.FirstOrDefault(x => x.Id == 1 && x.EstaActivo);

            clienteService.DeleteLogicalyAsync(1).GetAwaiter().GetResult();

            cliente = dbContext.Clientes.FirstOrDefault(x => x.Id == 1);

            Assert.That(cliente.EstaActivo == false);

        }

        [Test]
        public void Deberia_listar_los_clientes_y_coincidir_la_Cantidad_listada()
        {
            //Arrange
            var clienteService = TestHelper.GetClienteService(dbContext);

            //Act
            var listaClientes = clienteService.ListAllAsync().GetAwaiter().GetResult();

            var cantidadClientesEsperada = dbContext.Clientes.Count();

            //Assert
            Assert.That(cantidadClientesEsperada == listaClientes.Count);

        }

        [Test]
        public void Deberia_listar_los_clientes_activos_y_coincidir_la_Cantidad_listada()
        {
            //Arrange
            var clienteService = TestHelper.GetClienteService(dbContext);

            //Act
            var listaClientesActivos = clienteService.ListAllActivesAsync().GetAwaiter().GetResult();

            var cantidadClientesActivosEsperada = dbContext.Clientes.Where(x => x.EstaActivo).Count();

            //Assert
            Assert.That(cantidadClientesActivosEsperada == listaClientesActivos.Count);

        }

    }
}
