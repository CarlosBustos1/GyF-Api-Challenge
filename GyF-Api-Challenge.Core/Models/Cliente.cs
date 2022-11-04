using System;
using GyF_Api_Challenge.Core.Enums;

namespace GyF_Api_Challenge.Core.Models
{
    public class Cliente
    {
        public Cliente()
        {

        }
        public Cliente(string nombre)
        {
            Nombre = nombre;
        }

        public Cliente(string nombre, bool activo)
        {
            Nombre = nombre;
            EstaActivo = activo;
        }
        public int Id { get; set; }

        public string Nombre { get; set; }

        private DateTime _fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value.Date; }
        }

        public int Edad
        {
            get
            {
                var hoy = DateTime.Today;

                var edad = hoy.Year - FechaNacimiento.Year;

                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;


                return edad;
            }
        }

        public GeneroEnum Genero { get; set; }

        public string Cuil { get; set; }

        public string Telefono { get; set; }

        public bool EstaActivo { get; set; } = true;
    }
}
