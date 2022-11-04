using GyF_Api_Challenge.Core.Models;
using GyF_Api_Challenge.Data;
using GyF_Api_Challenge.Test.Helpers;
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
