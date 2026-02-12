using PracticaProgramada2.Data;
using PracticaProgramada2.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace PracticaProgramada2.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly AppDbContext _context;

        public GeneroRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Genero> ObtenerTodos()
            => _context.Generos
                .Include(g => g.Videojuegos)
                .ToList();

       public Genero? ObtenerPorId(int id)
        => _context.Generos
            .Include(g => g.Videojuegos)
            .FirstOrDefault(g => g.Id == id);


        public bool ExisteId(int id)
            => _context.Generos.Any(g => g.Id == id);

        public void Agregar(Genero genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();
        }

        public void Actualizar(Genero genero)
        {
            _context.Generos.Update(genero);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var genero = ObtenerPorId(id);
            if (genero != null)
            {
                _context.Generos.Remove(genero);
                _context.SaveChanges();
            }
        }
    }
}
