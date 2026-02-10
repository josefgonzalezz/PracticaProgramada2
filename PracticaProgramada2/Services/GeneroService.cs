using PracticaProgramada2.Models;
using PracticaProgramada2.Repositories;

namespace PracticaProgramada2.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;
        }

        public List<Genero> ObtenerTodos()
            => _repository.ObtenerTodos();

        public Genero? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);

        public bool CrearGenero(Genero genero)
        {
            if (_repository.ExisteId(genero.Id))
                return false;

            _repository.Agregar(genero);
            return true;
        }

        public bool EditarGenero(Genero genero)
        {
            if (!_repository.ExisteId(genero.Id))
                return false;

            _repository.Actualizar(genero);
            return true;
        }

        public bool EliminarGenero(int id)
        {
            if (!_repository.ExisteId(id))
                return false;

            _repository.Eliminar(id);
            return true;
        }
    }
}
