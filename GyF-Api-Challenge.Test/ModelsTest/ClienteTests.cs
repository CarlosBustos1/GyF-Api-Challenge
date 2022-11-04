using GyF_Api_Challenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Test.ModelsTest
{

    public class ClienteTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Cliente_Deberia_Tener_41_años_de_edad()
        {
            var cliente = new Cliente()
            {
                FechaNacimiento = DateTime.Today.AddYears(-41)
            };

            int edadEsperada = 41;

            Assert.That(edadEsperada == cliente.Edad);

        }
    }
}
