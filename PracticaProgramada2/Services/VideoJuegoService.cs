using PracticaProgramada2.Models;
using PracticaProgramada2.Data;
using Microsoft.EntityFrameworkCore;

namespace PracticaProgramada2.Services
{
    public class VideojuegoService : IVideojuegoService
    {
        private readonly AppDbContext _context;

        public VideojuegoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Videojuego> ObtenerTodos()
            => _context.Videojuegos.Include(v => v.Genero).OrderBy(v => v.Titulo).ToList();

        public Videojuego? ObtenerDetalle(int id)
            => _context.Videojuegos.Include(v => v.Genero).Include(v => v.Comentarios).FirstOrDefault(v => v.Id == id);

        public bool CrearVideojuego(Videojuego videojuego)
        {
            _context.Videojuegos.Add(videojuego);
            _context.SaveChanges();
            return true;
        }

        public bool EditarVideojuego(Videojuego videojuego)
        {
            var existe = _context.Videojuegos.Any(v => v.Id == videojuego.Id);
            if (!existe)
                return false;

            _context.Videojuegos.Update(videojuego);
            _context.SaveChanges();
            return true;
        }

        public bool EliminarVideojuego(int id)
        {
            var videojuego = _context.Videojuegos.Find(id);
            if (videojuego == null)
                return false;

            _context.Videojuegos.Remove(videojuego);
            _context.SaveChanges();
            return true;
        }

        
    }
}