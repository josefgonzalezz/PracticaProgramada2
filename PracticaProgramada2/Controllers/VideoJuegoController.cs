using PracticaProgramada2.Models;
using PracticaProgramada2.Services;
using Microsoft.AspNetCore.Mvc;

namespace PracticaProgramada2.Controllers
{
    [Route("videojuego")]
    public class VideojuegoController : Controller
    {
        private readonly IVideojuegoService _videojuegoService;

        public VideojuegoController(IVideojuegoService videojuegoService)
        {
            _videojuegoService = videojuegoService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var juegos = _videojuegoService.ObtenerTodos();
            return View(juegos);
        }

        [HttpGet("detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var juego = _videojuegoService.ObtenerDetalle(id);

            if (juego == null)
                return NotFound();

            return View(juego);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost("crear")]
        public IActionResult Crear(Videojuego videojuego)
        {
            if (!ModelState.IsValid)
                return View(videojuego);

            _videojuegoService.CrearVideojuego(videojuego);
            return RedirectToAction("Index");
        }


        [HttpGet("editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            var juego = _videojuegoService.ObtenerDetalle(id);

            if (juego == null)
                return NotFound();

            return View(juego);
        }

        [HttpPost("editar")]
        public IActionResult Editar(Videojuego videojuego)
        {
            if (!ModelState.IsValid)
                return View(videojuego);

            _videojuegoService.EditarVideojuego(videojuego);
            return RedirectToAction("Index");
        }


        [HttpGet("eliminar/{id:int}")]
        public IActionResult Eliminar(int id)
        {
            var juego = _videojuegoService.ObtenerDetalle(id);

            if (juego == null)
                return NotFound();

            return View(juego);
        }

        [HttpPost("eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            _videojuegoService.EliminarVideojuego(id);
            return RedirectToAction("Index");
        }
        [HttpGet("imagen/{id:int}")]
        public FileResult Imagen(int id)
        {
            var juego = _videojuegoService.ObtenerDetalle(id);

            if (juego == null || string.IsNullOrEmpty(juego.ImagePath))
                return null;

            return File(juego.ImagePath, "image/jpeg", "imagen.jpg");
        }

    }
}
