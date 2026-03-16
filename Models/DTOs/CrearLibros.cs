using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca_Softek.Models.DTOs
{
    public class CrearLibros
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El año es obligatorio")]
        public int Year { get; set; }
        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "El número de páginas es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ser al menos 1 página")]
        public int NumeroPaginas { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un autor")]
        public Guid AutorId { get; set; }
    }
}