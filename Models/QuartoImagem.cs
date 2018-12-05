using System.Collections.Generic;

namespace easy_hotel_backend.Models
{
    public class QuartoImagem
    {
        public int QuartoImagemId { get; set; }
        public int QuartoId { get; set; }
        public int ImagemId { get; set; }
        public Imagem Imagem { get; set; }
    }
}