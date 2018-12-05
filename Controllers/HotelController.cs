using System.Collections.Generic;
using easy_hotel_backend.Models;
using easy_hotel_backend.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace easy_hotel_backend.Controllers
{
    [Route("api/[Controller]")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepositorio;

        public HotelController(IHotelRepository hotelRepo)
        {
            _hotelRepositorio = hotelRepo;

        }

        [HttpGet]
        public IEnumerable<Hotel> GetAll()
        {
            return _hotelRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetHotel")]
        public IActionResult getById(long id)
        {
            var hotel = _hotelRepositorio.Find(id);
            if (hotel == null)
                return NotFound();

            return new ObjectResult(hotel);
        }
        [HttpPost]
        public IActionResult Crate([FromBody] Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }
            _hotelRepositorio.Add(hotel);
            return CreatedAtRoute("GetHotel", new { id = hotel.HotelId }, hotel);
        }

        [HttpPut]
        public IActionResult Update(long id, [FromBody] Hotel hotel)
        {
            if (hotel == null || hotel.HotelId != id)
            {
                return BadRequest();
            }
            var _hotel = _hotelRepositorio.Find(id);
            if (_hotel == null)
            {
                return NotFound();
            }
            _hotel.Email = hotel.Email;
            _hotel.Nome = hotel.Nome;
            _hotel.Descricao = hotel.Descricao;
            _hotel.Cidade = hotel.Cidade;
            _hotel.Estado = hotel.Estado;
            _hotel.Avaliacao = hotel.Avaliacao;

            _hotelRepositorio.Update(hotel);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var hotel = _hotelRepositorio.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            _hotelRepositorio.Remove(id);
            return new ContentResult();
        }
    }
}
