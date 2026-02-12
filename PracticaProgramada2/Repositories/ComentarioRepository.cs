using PracticaProgramada2.Data;
using PracticaProgramada2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PracticaProgramada2.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDbContext _context;

        public ComentarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Comentario> ObtenerTodos()
            => _context.Comentarios
                .Include(c => c.Videojuego)
                .OrderBy(c => c.Fecha)
                .ToList();

        public Comentario? ObtenerPorId(int id)
            => _context.Comentarios
                .Include(c => c.Videojuego)
                .FirstOrDefault(c => c.Id == id);

        public bool ExisteId(int id)
            => _context.Comentarios.Any(c => c.Id == id);

        public void Agregar(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();
        }

        public void Actualizar(Comentario comentario)
        {
            _context.Comentarios.Update(comentario);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var comentario = ObtenerPorId(id);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                _context.SaveChanges();
            }
        }
    }
}
