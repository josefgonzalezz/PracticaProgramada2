using PracticaProgramada2.Models;
using PracticaProgramada2.Services;
using Microsoft.AspNetCore.Mvc;

namespace PracticaProgramada2.Controllers
{
    [Route("genero")]
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var generos = _generoService.ObtenerTodos();
            return View(generos);
        }

        [HttpGet("detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var genero = _generoService.ObtenerDetalle(id);

            if (genero == null)
                return NotFound();

            return View(genero);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost("crear")]
        public IActionResult Crear(Genero genero)
        {
            if (!ModelState.IsValid)
                return View(genero);

            _generoService.CrearGenero(genero);
            return RedirectToAction("Index");
        }


        [HttpGet("editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            var genero = _generoService.ObtenerDetalle(id);
            if (genero == null)
                return NotFound();

            return View(genero);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult Editar(int id, Genero genero)
        {
            if (!ModelState.IsValid)
                return View(genero);

            _generoService.EditarGenero(genero);
            return RedirectToAction("Index");
        }


        [HttpGet("eliminar/{id:int}")]
        public IActionResult Eliminar(int id)
        {
            var genero = _generoService.ObtenerDetalle(id);

            if (genero == null)
                return NotFound();

            return View(genero);
        }

        [HttpPost("eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            _generoService.EliminarGenero(id);
            return RedirectToAction("Index");
        }
    }
}
