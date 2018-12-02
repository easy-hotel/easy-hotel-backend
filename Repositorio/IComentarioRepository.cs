using System.Collections.Generic;
using easy_hotel_backend.Models;

namespace easy_hotel_backend.Repositorio
{
    public interface IComentarioRepository
    {
        void Add(Comentario comentario);
        IEnumerable<Comentario> GetByQuartoId(long id);

    }
}