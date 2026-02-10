using PracticaProgramada2.Models;
using System.Collections.Generic;

namespace PracticaProgramada2.Services
{
    public interface IVideojuegoService
    {
        List<Videojuego> ObtenerTodos();
        Videojuego? ObtenerDetalle(int id);
        bool CrearVideojuego(Videojuego videojuego);
        bool EditarVideojuego(Videojuego videojuego);
        bool EliminarVideojuego(int id);
    }
}
