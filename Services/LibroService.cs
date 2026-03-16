using Biblioteca_Softek.Data;
using Biblioteca_Softek.Interfaces;
using Biblioteca_Softek.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Biblioteca_Softek.Exceptions;

namespace Biblioteca_Softek.Services
{
    public class LibroService : ILibroService
    {
        private readonly BibliotecaDbContext _context;

        public LibroService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task RegistrarNuevoLibroAsync(CrearLibros libro)
        {
            var autor = _context.Autor.FirstOrDefault(a => a.Id == libro.AutorId);

            if (autor == null)
            {
                throw new Excepciones("Autor no encontrado");
            }

            int MaximoLibros = 30;
            int LibrosActuales = await _context.Libros.CountAsync();

            if (LibrosActuales >= MaximoLibros)
            {
                throw new Excepciones("No se pueden registrar más libros, se ha alcanzado el límite.");
            }

            var nuevoLibro = new Libro
            {
                Id = Guid.NewGuid(),
                Titulo = libro.Titulo,
                Year = libro.Year,
                Genero = libro.Genero,
                NumeroPaginas = libro.NumeroPaginas,
                AutorId = libro.AutorId
            };

            _context.Libros.Add(nuevoLibro);

            await _context.SaveChangesAsync();
        }
    }
}