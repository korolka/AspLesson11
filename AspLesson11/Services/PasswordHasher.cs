using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace AspLesson11.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const string Salt = "fKk+GkLvQBjAhe2VBDBnwg==";
        public string GeneratePassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2
                (
                password: password,
                salt: Convert.FromBase64String(Salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 32
                ));
        }
    }
}
