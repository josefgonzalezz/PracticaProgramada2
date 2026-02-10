using PracticaProgramada2.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaProgramada2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Videojuego> Videojuegos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}

