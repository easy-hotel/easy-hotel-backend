namespace easy_hotel_backend.Models
{
    public class Favorito
    {
        public int FavoritoId { get; set; }
        public int HotelId { get; set; }
        public int UsuarioId { get; set; }
    }
}