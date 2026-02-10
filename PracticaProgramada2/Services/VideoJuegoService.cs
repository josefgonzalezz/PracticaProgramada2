using PracticaProgramada2.Models;
using PracticaProgramada2.Repositories;

namespace PracticaProgramada2.Services
{
    public class VideojuegoService : IVideojuegoService
    {
        private readonly IVideojuegoRepository _repository;

        public VideojuegoService(IVideojuegoRepository repository)
        {
            _repository = repository;
        }

        public List<Videojuego> ObtenerTodos()
            => _repository.ObtenerTodos();

        public Videojuego? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);

        public bool CrearVideojuego(Videojuego videojuego)
        {
            if (_repository.ExisteId(videojuego.Id))
                return false;

            _repository.Agregar(videojuego);
            return true;
        }

        public bool EditarVideojuego(Videojuego videojuego)
        {
            if (!_repository.ExisteId(videojuego.Id))
                return false;

            _repository.Actualizar(videojuego);
            return true;
        }

        public bool EliminarVideojuego(int id)
        {
            if (!_repository.ExisteId(id))
                return false;

            _repository.Eliminar(id);
            return true;
        }
    }
}
