using PracticaProgramada2.Models;
using System.Collections.Generic;

namespace PracticaProgramada2.Services
{
    public interface IGeneroService
    {
        List<Genero> ObtenerTodos();
        Genero? ObtenerDetalle(int id);
        bool CrearGenero(Genero genero);
        bool EditarGenero(Genero genero);
        bool EliminarGenero(int id);
    }
}
