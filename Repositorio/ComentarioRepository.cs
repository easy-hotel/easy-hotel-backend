using System.Collections.Generic;
using System.Linq;
using easy_hotel_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace easy_hotel_backend.Repositorio
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ApiDbContext _contexto;
        public ComentarioRepository(ApiDbContext ctx)
        {
            _contexto = ctx;
        }

        void IComentarioRepository.Add(Comentario comentario)
        {
            _contexto.Comentario.Add(comentario);
            _contexto.SaveChanges();
        }

        IEnumerable<Comentario> IComentarioRepository.GetByQuartoId(long id)
        {
            IEnumerable<Comentario> comentarios = _contexto.Comentario.Where(c => c.QuartoId == id)
            .GroupJoin(_contexto.Usuarios.ToList(), c => c.usuario.UsuarioId, u => u.UsuarioId, (comentario, usuario) => comentario)
            .OrderByDescending(c => c.ComentarioId);
            return comentarios;
        }
    }
}