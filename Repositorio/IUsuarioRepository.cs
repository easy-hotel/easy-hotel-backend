using System.Collections.Generic;

namespace easy_hotel_backend.Repositorio
{
    public interface IUsuarioRepository
    {
        void Add(Usuario user);
        IEnumerable<Usuario> GetAll();
        Usuario Find(long id);
        void Remove(long id);
        void Update(Usuario user);
    }
}