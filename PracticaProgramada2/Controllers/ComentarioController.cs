using PracticaProgramada2.Models;
using PracticaProgramada2.Services;
using Microsoft.AspNetCore.Mvc;

namespace PracticaProgramada2.Controllers
{
    [Route("comentario")]
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;

        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var comentarios = _comentarioService.ObtenerTodos();
            return View(comentarios);
        }

        [HttpGet("detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var comentario = _comentarioService.ObtenerDetalle(id);

            if (comentario == null)
                return NotFound();

            return View(comentario);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost("crear")]
        public IActionResult Crear(Comentario comentario)
        {
            if (!ModelState.IsValid)
                return View(comentario);

            _comentarioService.CrearComentario(comentario);
            return RedirectToAction("Index");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            var comentario = _comentarioService.ObtenerDetalle(id);

            if (comentario == null)
                return NotFound();

            return View(comentario);
        }

        [HttpPost("editar")]
        public IActionResult Editar(Comentario comentario)
        {
            if (!ModelState.IsValid)
                return View(comentario);

            _comentarioService.EditarComentario(comentario);
            return RedirectToAction("Index");
        }


        [HttpGet("eliminar/{id:int}")]
        public IActionResult Eliminar(int id)
        {
            var comentario = _comentarioService.ObtenerDetalle(id);

            if (comentario == null)
                return NotFound();

            return View(comentario);
        }

        [HttpPost("eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            _comentarioService.EliminarComentario(id);
            return RedirectToAction("Index");
        }
    }
}
