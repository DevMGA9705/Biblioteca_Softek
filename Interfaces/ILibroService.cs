using Biblioteca_Softek.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Softek.Interfaces
{
    public interface ILibroService
    {
        Task RegistrarNuevoLibroAsync(CrearLibros libro);
    }
}
