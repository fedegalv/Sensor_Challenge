using Microsoft.EntityFrameworkCore;
using Sensor_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.DBContext
{
    public class SensorDbContext: DbContext
    {
        public SensorDbContext(DbContextOptions<SensorDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
