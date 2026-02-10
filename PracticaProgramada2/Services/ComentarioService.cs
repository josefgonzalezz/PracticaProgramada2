using PracticaProgramada2.Models;
using PracticaProgramada2.Repositories;

namespace PracticaProgramada2.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _repository;

        public ComentarioService(IComentarioRepository repository)
        {
            _repository = repository;
        }

        public List<Comentario> ObtenerTodos()
            => _repository.ObtenerTodos();

        public Comentario? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);

        public bool CrearComentario(Comentario comentario)
        {
            if (_repository.ExisteId(comentario.Id))
                return false;

            _repository.Agregar(comentario);
            return true;
        }

        public bool EditarComentario(Comentario comentario)
        {
            if (!_repository.ExisteId(comentario.Id))
                return false;

            _repository.Actualizar(comentario);
            return true;
        }

        public bool EliminarComentario(int id)
        {
            if (!_repository.ExisteId(id))
                return false;

            _repository.Eliminar(id);
            return true;
        }
    }
}
