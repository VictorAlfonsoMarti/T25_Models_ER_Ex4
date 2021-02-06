using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using T25_Models_ER_Ex4.Model;

namespace T25_Models_ER_Ex4
{
    public class APIContext : DbContext
    {// IMPORTAMOS LOS METODOS DE DBCONTEXT
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        // ATRIBUTOS, GETTERS Y SETTERS
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }

        // CREAMOS EL MODELO
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(pelicula =>
            {
                // NOMBRE DE LA TABLA
                pelicula.ToTable("PELICULAS");

                // DEFINICIÓN DE COLUMNAS
                pelicula.Property(e => e.Codigo)
                    .HasColumnName("Codigo");

                pelicula.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                pelicula.Property(e => e.CalificacionEdad)
                    .HasColumnName("CalificacionEdad");

                // DEFINICIÓN DE CLAVES
                pelicula.HasKey(k => k.Codigo);
            });

            modelBuilder.Entity<Sala>(sala =>
            {
                // NOMBRE DE LA TABLA
                sala.ToTable("SALAS");

                // DEFINICIÓN DE COLUMNAS
                sala.Property(e => e.Codigo)
                    .HasColumnName("Codigo");

                sala.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                sala.Property(e => e.Pelicula)
                    .HasColumnName("Pelicula");

                // DEFINICIÓN DE CLAVES
                sala.HasKey(k => k.Codigo);

                // DEFINICIÓN DE RELACIONES
                sala.HasOne(r => r.Peliculas)
                    .WithMany(m => m.Salas)
                    .HasForeignKey(f => f.Pelicula)
                    .HasConstraintName("Pelicula_fk");
            });
        }
    }
}
