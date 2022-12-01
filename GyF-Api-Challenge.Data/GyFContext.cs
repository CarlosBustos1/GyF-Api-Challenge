using GyF_Api_Challenge.Core.Models;
using GyF_Api_Challenge.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace GyF_Api_Challenge.Data
{
    public class GyFContext :IdentityDbContext
    {
      
        public virtual DbSet<Cliente> Clientes { get; set; }

        public GyFContext():base()
        {

        }
        public GyFContext(DbContextOptions<GyFContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

        }

        protected  override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteConfiguration());

     
        }
    }
}
