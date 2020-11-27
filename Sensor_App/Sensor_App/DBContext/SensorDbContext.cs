using Microsoft.EntityFrameworkCore;
using Sensor_App.Models;

namespace Sensor_App.DBContext
{
    public class SensorDbContext : DbContext
    {
        public SensorDbContext(DbContextOptions<SensorDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PermisoTipo> PermisoTipos { get; set; }
        public DbSet<Seguro> Seguros { get; set; }

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
