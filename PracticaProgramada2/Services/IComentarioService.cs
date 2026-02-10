using PracticaProgramada2.Models;
using System.Collections.Generic;

namespace PracticaProgramada2.Services
{
    public interface IComentarioService
    {
        List<Comentario> ObtenerTodos();
        Comentario? ObtenerDetalle(int id);
        bool CrearComentario(Comentario comentario);
        bool EditarComentario(Comentario comentario);
        bool EliminarComentario(int id);
    }
}
