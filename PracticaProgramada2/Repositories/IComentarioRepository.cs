using PracticaProgramada2.Models;
using System.Collections.Generic;

namespace PracticaProgramada2.Repositories
{
    public interface IComentarioRepository
    {
        List<Comentario> ObtenerTodos();
        Comentario? ObtenerPorId(int id);
        bool ExisteId(int id);
        void Agregar(Comentario comentario);
        void Actualizar(Comentario comentario);
        void Eliminar(int id);
    }
}
