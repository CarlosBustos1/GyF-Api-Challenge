using GyF_Api_Challenge.Core.Enums;

namespace GyF_Api_Challenge.Api.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Cuil { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public GeneroEnum Genero { get; set; }

        public int Edad { get; }
    }
}
