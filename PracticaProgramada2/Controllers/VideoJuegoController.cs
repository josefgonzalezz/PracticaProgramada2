using PracticaProgramada2.Models;
using PracticaProgramada2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PracticaProgramada2.Controllers
{
    [Route("videojuego")]
    public class VideojuegoController : Controller
    {
        private readonly IVideojuegoService _videojuegoService;
        private readonly IGeneroService _generoService;

        public VideojuegoController(IVideojuegoService videojuegoService, IGeneroService generoService)
        {
            _videojuegoService = videojuegoService;
            _generoService = generoService;
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
            ViewBag.Generos = new SelectList(_generoService.ObtenerTodos(), "Id", "Nombre");
            return View(new VideojuegoViewModel());
        }

        [HttpPost("crear")]
        public IActionResult Crear(VideojuegoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Generos = new SelectList(_generoService.ObtenerTodos(), "Id", "Nombre");
                return View(model);
            }

            var videojuego = new Videojuego
            {
                Titulo = model.Titulo,
                Plataforma = model.Plataforma,
                Precio = model.Precio,
                GeneroId = model.GeneroId,
                ImagePath = model.ImagePath
            };

            _videojuegoService.CrearVideojuego(videojuego);
            return RedirectToAction("Index");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            var juego = _videojuegoService.ObtenerDetalle(id);
            if (juego == null)
                return NotFound();

            var model = new VideojuegoViewModel
            {
                Id = juego.Id,
                Titulo = juego.Titulo,
                Plataforma = juego.Plataforma,
                Precio = juego.Precio,
                GeneroId = juego.GeneroId,
                ImagePath = juego.ImagePath
            };

            ViewBag.Generos = new SelectList(_generoService.ObtenerTodos(), "Id", "Nombre");
            return View(model);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult Editar(int id, VideojuegoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Generos = new SelectList(_generoService.ObtenerTodos(), "Id", "Nombre");
                return View(model);
            }

            var videojuego = _videojuegoService.ObtenerDetalle(id);
            if (videojuego == null)
                return NotFound();

            videojuego.Titulo = model.Titulo;
            videojuego.Plataforma = model.Plataforma;
            videojuego.Precio = model.Precio;
            videojuego.GeneroId = model.GeneroId;
            videojuego.ImagePath = model.ImagePath;

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
    }
}