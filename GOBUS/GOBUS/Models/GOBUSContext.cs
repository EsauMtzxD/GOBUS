using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GOBUS.Models
{
        [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
        public class GOBUSContext : DbContext
        {
            public GOBUSContext() : base("GOBUSContext")
            {
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GOBUSContext, GOBUS.Migrations.Configuration>());
                // Database.SetInitializer<GOBUSContext>(new GOBUSDbInitializer());
            }


            public DbSet<Cita> Citas { get; set; }
            public DbSet<Servicio> Servicios { get; set; }
            public DbSet<Sucursale> Sucursales { get; set; }
            public DbSet<Cliente> Clientes { get; set; }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }

        }
}