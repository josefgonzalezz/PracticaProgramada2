using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaProgramada2.Models
{
    public class Videojuego
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Plataforma { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey(nameof(Genero))]
        public int GeneroId { get; set; }

        public Genero? Genero { get; set; }

        public List<Comentario>? Comentarios { get; set; }
    }
}
