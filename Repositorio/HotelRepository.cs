using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace easy_hotel_backend.Repositorio
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApiDbContext _contexto;
        public HotelRepository(ApiDbContext ctx)
        {
            _contexto = ctx;
        }

        public void Add(Hotel hotel)
        {
            _contexto.Hotels.Add(hotel);
            _contexto.SaveChanges();
        }

        Hotel IHotelRepository.Find(long id)
        {
            return _contexto.Hotels.FirstOrDefault(h => h.HotelId == id);
        }

        public IEnumerable<Hotel> GetAll()
        {
            var hotels = _contexto.Hotels.Join(_contexto.Imagem.ToList(), h => h.ImagemId, i => i.ImagemId, (hotel, imagem) => hotel);
            return hotels;
        }

        void IHotelRepository.Remove(long id)
        {
            var entity = _contexto.Hotels.First(h => h.HotelId == id);
            _contexto.Hotels.Remove(entity);
            _contexto.SaveChanges();
        }

        void IHotelRepository.Update(Hotel hotel)
        {
            _contexto.Hotels.Update(hotel);
            _contexto.SaveChanges();
        }
    }

}