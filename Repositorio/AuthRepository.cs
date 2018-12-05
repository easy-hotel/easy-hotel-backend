using System.Linq;
namespace easy_hotel_backend.Repositorio

{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApiDbContext _contexto;
        public AuthRepository(ApiDbContext ctx)
        {
            _contexto = ctx;
        }

        Usuario IAuthRepository.Auth(string email, string senha)
        {
            return _contexto.Usuarios.Where(u => u.Email == email).FirstOrDefault(u => u.Senha == senha);
        }
    }
}