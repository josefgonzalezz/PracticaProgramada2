using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaProgramada2.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TextoComentario { get; set; }

        [Range(1, 5)]
        public int Valoracion { get; set; }

        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(Videojuego))]
        public int VideojuegoId { get; set; }

        public Videojuego? Videojuego { get; set; }
    }
}
