using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaProgramada2.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public List<Videojuego>? Videojuegos { get; set; }
    }
}

