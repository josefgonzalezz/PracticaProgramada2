using PracticaProgramada2.Models;
using PracticaProgramada2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace PracticaProgramada2.Controllers
{
    [Route("comentario")]
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;
        private readonly IVideojuegoService _videojuegoService;

        public ComentarioController(IComentarioService comentarioService, IVideojuegoService videojuegoService)
        {
            _comentarioService = comentarioService;
            _videojuegoService = videojuegoService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var comentarios = _comentarioService.ObtenerTodos();

            if (TempData["Mensaje"] != null)
            {
                ViewBag.Mensaje = TempData["Mensaje"].ToString();
            }

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
            ViewBag.Videojuegos = new SelectList(_videojuegoService.ObtenerTodos(), "Id", "Titulo");
            return View();
        }

        [HttpPost("crear")]
        public IActionResult Crear(Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                if (Request.Headers["Referer"].ToString().Contains("/comentario/crear"))
                {
                    ViewBag.Videojuegos = new SelectList(_videojuegoService.ObtenerTodos(), "Id", "Titulo");
                    return View(comentario);
                }

                TempData["Error"] = "Por favor complete todos los campos correctamente.";
                return RedirectToAction("Detalle", "Videojuego", new { id = comentario.VideojuegoId });
            }

            comentario.Fecha = DateTime.Now;

            _comentarioService.CrearComentario(comentario);
            TempData["Mensaje"] = "Comentario agregado exitosamente.";

            return RedirectToAction("Detalle", "Videojuego", new { id = comentario.VideojuegoId });
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            var comentario = _comentarioService.ObtenerDetalle(id);
            if (comentario == null)
                return NotFound();

            ViewBag.Videojuegos = new SelectList(_videojuegoService.ObtenerTodos(), "Id", "Titulo");
            return View(comentario);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult Editar(int id, Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Videojuegos = new SelectList(_videojuegoService.ObtenerTodos(), "Id", "Titulo");
                return View(comentario);
            }

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
            TempData["Mensaje"] = "Comentario eliminado exitosamente.";
            return RedirectToAction("Index");
        }
    }
}