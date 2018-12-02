using System;

namespace easy_hotel_backend.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public int QuartoId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario usuario { get; set; }
        public string Texto { get; set; }
        public int Avaliacao { get; set; }
        public DateTime data { get; set; }

    }
}