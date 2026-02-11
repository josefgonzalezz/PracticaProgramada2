using System.ComponentModel.DataAnnotations;

namespace PracticaProgramada2.Models
{
    public class VideojuegoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Plataforma { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Url]
        public string? ImagePath { get; set; }

        public int? GeneroId { get; set; }
    }
}