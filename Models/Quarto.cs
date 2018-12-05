using System.Collections.Generic;

namespace easy_hotel_backend.Models
{
    public class Quarto
    {
        public int QuartoId { get; set; }
        public int HotelId { get; set; }
        public string TipoQuarto { get; set; }
        public string Descricao { get; set; }
        public int AvaliacaoQuarto { get; set; }
        public double Valor { get; set; }
        public List<QuartoImagem> QuartoImagems { get; set; }
        public Hotel Hotel { get; set; }

    }
}