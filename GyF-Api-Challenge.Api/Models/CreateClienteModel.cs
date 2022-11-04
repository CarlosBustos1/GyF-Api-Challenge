using GyF_Api_Challenge.Core.Enums;

namespace GyF_Api_Challenge.Api.Models
{
    public class BaseClienteModel
    {
        public string Nombre { get; set; }

        public string Cuil { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public GeneroEnum Genero { get; set; }
    }
}
