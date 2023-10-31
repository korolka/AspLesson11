namespace AspLesson11.Services
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
    }
}
