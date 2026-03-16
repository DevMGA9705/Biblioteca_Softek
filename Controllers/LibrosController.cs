using Biblioteca_Softek.Data;
using Biblioteca_Softek.Exceptions;
using Biblioteca_Softek.Interfaces;
using Biblioteca_Softek.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_Softek.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroService libroService;
        private readonly BibliotecaDbContext _context;

        public LibrosController(ILibroService libroService, BibliotecaDbContext context)
        {
            this.libroService = libroService;
            _context = context;
        }

        public ActionResult RegistrarLibros()
        {

            var generos = new List<string> {
                "Romance", "Ciencia Ficción", "Misterio",
                "Terror", "Histórica", "Fantasía",
                "Cuento", "Poesía", "Teatro"
            };
            ViewBag.Generos = new SelectList(generos);
            ViewBag.Autores = new SelectList(_context.Autor.ToList(), "Id", "Nombre_Completo");
            return View();
        }

        [HttpPost]
        [Route("Libros/Guardar")] 
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>RegistrarLibros(CrearLibros libro)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    await libroService.RegistrarNuevoLibroAsync(libro);
                    return RedirectToAction("Index", "Home");
                }
                catch (Excepciones ex)
                {
                    ModelState.AddModelError("No se pudo Crear el libro", ex.Message);
                }
            }
            ViewBag.Autores = new SelectList(_context.Autor, "Id", "Nombre", libro.AutorId);
            return View(libro);
        }
    }
}