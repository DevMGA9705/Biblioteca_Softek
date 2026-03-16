using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Biblioteca_Softek.Models.DTOs
{
    public class Autor
    {
        public Guid Id { get; set; }
        [Column("Nombre_Completo")]
        public string Nombre_Completo { get; set; }
        [Column("Fecha_Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}