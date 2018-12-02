using System.Collections.Generic;
using easy_hotel_backend.Models;
using easy_hotel_backend.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace easy_hotel_backend.Controllers
{
    [Route("api/[controller]")]
    public class ComentarioController : Controller
    {
        private readonly IComentarioRepository _comentarioRepositorio;

        public ComentarioController(IComentarioRepository comentarioRepo)
        {
            _comentarioRepositorio = comentarioRepo;

        }

        [HttpPost]
        public IActionResult Crate([FromBody] Comentario comentario)
        {
            if (comentario == null)
            {
                return BadRequest();
            }
            _comentarioRepositorio.Add(comentario);
            return CreatedAtRoute("GetReserva", new { id = comentario.ComentarioId }, comentario);
        }

        [HttpGet("{id}", Name = "GetComentario")]
        public IEnumerable<Comentario> getByQuartoId(long id)
        {
            return _comentarioRepositorio.GetByQuartoId(id);
        }
    }
}