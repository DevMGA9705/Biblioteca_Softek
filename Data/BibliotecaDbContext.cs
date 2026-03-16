using Biblioteca_Softek.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteca_Softek.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext() : base("name=DefaultConnection") { Database.SetInitializer<BibliotecaDbContext>(null); }


        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>()
                .ToTable("Autor")
                .HasKey(a => a.Id);

            modelBuilder.Entity<Autor>()
                .Property(a => a.Nombre_Completo)
                .HasColumnName("Nombre_Completo");

            modelBuilder.Entity<Autor>()
                .Property(a => a.Fecha_Nacimiento)
                .HasColumnName("Fecha_Nacimiento");


            modelBuilder.Entity<Libro>()
                .ToTable("Libros")
                .HasRequired(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.AutorId);
        }

    }
}