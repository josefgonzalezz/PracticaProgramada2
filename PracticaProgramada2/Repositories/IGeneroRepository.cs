using PracticaProgramada2.Models;
using System.Collections.Generic;

namespace PracticaProgramada2.Repositories
{
    public interface IGeneroRepository
    {
        List<Genero> ObtenerTodos();
        Genero? ObtenerPorId(int id);
        bool ExisteId(int id);
        void Agregar(Genero genero);
        void Actualizar(Genero genero);
        void Eliminar(int id);
    }
}
