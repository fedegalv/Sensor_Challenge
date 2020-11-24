using Microsoft.EntityFrameworkCore;
using Sensor_App.Models;
using Sensor_App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.DBContext
{
    public class SensorDbContext : DbContext
    {
        public SensorDbContext(DbContextOptions<SensorDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cliente>(entity =>
            //{

            //    entity.HasIndex(e => e.IdSeguro)
            //        .HasName("FK_cliente_seguro");
            //    entity.Property(e => e.IdSeguro).HasColumnName("idSeguro");
            //    entity.HasOne(d => d.Seguro)
            //        .WithOne(p => p.)
            //        .HasForeignKey(d => d.IdRepresentante)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_siniestro_representante");

            //});
        }
    }
}
