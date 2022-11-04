using GyF_Api_Challenge.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Core.Dtos
{
    public  class ClienteDto: BaseClienteDto
    {
        public int Id { get; set; }

    }

    public class BaseClienteDto
    {
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Cuil { get; set; }

        public string Telefono { get; set; }

        public GeneroEnum Genero { get; set; }

        public int Edad { get; private set; }
    }

    public class UpdateClienteDto : BaseClienteDto
    {
        public int Id { get; set; }

    }
}
