using PracticaProgramada2.Models;

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