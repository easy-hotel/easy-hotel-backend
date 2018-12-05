namespace easy_hotel_backend.Repositorio
{
    public interface IAuthRepository
    {
        Usuario Auth(string email, string senha);
    }
}