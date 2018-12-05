using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public class QuartoRepository : IQuartoRepository
    {
        private readonly ApiDbContext _contexto;
        public QuartoRepository(ApiDbContext ctx)
        {
            _contexto = ctx;
        }
        void IQuartoRepository.Add(Quarto quarto)
        {
            _contexto.Quarto.Add(quarto);
            _contexto.SaveChanges();
        }

        Quarto IQuartoRepository.Find(long id)
        {
            // Join QuartoImagem com Imagem
            var quartoImagems = _contexto.QuartoImagem.GroupJoin(_contexto.Imagem.ToList(), qi => qi.ImagemId, i => i.ImagemId, (quartoImagem, imagem) => quartoImagem);
            // get quarto
            var quarto = _contexto.Quarto.FirstOrDefault(q => q.QuartoId == id);
            // set hotel 
            quarto.Hotel = _contexto.Hotels.Find(quarto.HotelId);
            // set imagems
            quarto.QuartoImagems = quartoImagems.Where(q => q.QuartoId == quarto.QuartoId).ToList();

            return quarto;
        }

        IEnumerable<Quarto> IQuartoRepository.GetAll()
        {
            // Join QuartoImagem com Imagem
            var quartoImagems = _contexto.QuartoImagem.GroupJoin(_contexto.Imagem.ToList(), qi => qi.ImagemId, i => i.ImagemId, (quartoImagem, imagem) => quartoImagem);
            // join Quarto com Hotels
            var quartosHotel = _contexto.Quarto.GroupJoin(_contexto.Hotels.ToList(), q => q.HotelId, h => h.HotelId, (quarto, hotel) => quarto);
            // Join quartoImagems com QuartosHotel
            var quartos = quartosHotel.GroupJoin(quartoImagems.ToList(), q => q.QuartoId, qi => qi.QuartoId, (quarto, quartoImagem) => quarto);

            return quartos;
        }

        IEnumerable<Quarto> IQuartoRepository.GetAllByHotelId(long HotelId)
        {
            // Join QuartoImagem com Imagem
            var quartoImagems = _contexto.QuartoImagem.GroupJoin(_contexto.Imagem.ToList(), qi => qi.ImagemId, i => i.ImagemId, (quartoImagem, imagem) => quartoImagem);
            // join Quarto com Hotels
            var quartosHotel = _contexto.Quarto.Where(q => q.HotelId == HotelId).GroupJoin(_contexto.Hotels.ToList(), q => q.HotelId, h => h.HotelId, (quarto, hotel) => quarto);
            // Join quartoImagems com QuartosHotel
            var quartos = quartosHotel.GroupJoin(quartoImagems.ToList(), q => q.QuartoId, qi => qi.QuartoId, (quarto, quartoImagem) => quarto);

            return quartos;
        }

        void IQuartoRepository.Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        void IQuartoRepository.Update(Quarto quarto)
        {
            throw new System.NotImplementedException();
        }
    }
}