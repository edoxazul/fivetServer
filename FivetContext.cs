using System.Reflection;
using Fivet.ZeroIce.model;
using Microsoft.EntityFrameworkCore;

namespace Fivet.Dao
{
    public class FivetContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source =fivet.db", options =>
             {
                 options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
             });

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// On Model Creating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(p =>
            {
                // Primary Key
                p.HasKey(p => p.uid);
                // Required rut
                p.Property(p => p.rut).IsRequired();
                // Email is required
                p.Property(p => p.email).IsRequired();
                //Email is unique
                p.HasIndex(p => p.email).IsUnique();

            });

            // Insert the data
            modelBuilder.Entity<Persona>().HasData(
                new Persona()
                {
                    uid = 1,
                    rut = "190878635",
                    nombre = "Eduardo",
                    apellido = "Alvarez",
                    direccion = "Hola #2908",
                    telefonoFijo = 3248923,
                    telefonoMovil = 32479832,
                    email = "eas010@alumnos.ucn.cl"

                }
            );
        }

    }
}