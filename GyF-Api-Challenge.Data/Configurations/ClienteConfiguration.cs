using GyF_Api_Challenge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id);

            builder
                .Property(m => m.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder
              .Property(m => m.EstaActivo)
              .HasColumnName("Activo");

            builder
               .Property(m => m.Telefono)
               .HasColumnName("telefono")
               .HasColumnType("varchar")
               .HasMaxLength(100);

            builder
               .Property(m => m.Cuil)
               .HasColumnName("cuil")
               .HasColumnType("varchar")
               .HasMaxLength(13);


            builder
               .Property(m => m.Genero)
               .HasColumnName("genero");

            builder
               .Property(m => m.FechaNacimiento)
               .HasColumnName("fechaNacimiento");
            
            builder
              .Ignore(m => m.Edad);


        }
    }
}
