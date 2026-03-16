using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca_Softek.Models.DTOs
{
    public class Libro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int Year { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }

        public Guid AutorId { get; set; }

        public virtual Autor Autor { get; set; }
    }
}