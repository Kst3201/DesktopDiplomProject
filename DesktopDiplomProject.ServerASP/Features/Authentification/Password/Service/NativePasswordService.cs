using System.Security.Cryptography;

namespace DesktopDiplomProject.ServerASP.Features.Authentification.Password.Cryptographer
{
    public class NativePasswordService : IPasswordService
    {
        private const int ITERATIONSCOUNT = 100000;
        private const int HASHSIZE = 32;
        private const int SALTSIZE = 16;

        public string GetHashPassword(string password)
        {
            byte[] salt = new byte[SALTSIZE];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = GeneratePDFDF2Hash(password, salt, ITERATIONSCOUNT, HASHSIZE);
            byte[] hashBytes = new byte[HASHSIZE + SALTSIZE];
            Array.Copy(salt, 0, hashBytes, 0, SALTSIZE);
            Array.Copy(hash, 0, hashBytes, SALTSIZE, HASHSIZE);
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string password, string dbPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(dbPassword);

            byte[] salt = new byte[SALTSIZE];
            Array.Copy(hashBytes, 0, salt, 0, SALTSIZE);

            byte[] newPassHash = GeneratePDFDF2Hash(password, salt, ITERATIONSCOUNT, HASHSIZE);

            byte[] storedPassHash = new byte[HASHSIZE];
            Array.Copy(hashBytes, SALTSIZE, storedPassHash, 0, HASHSIZE);

            return CryptographicOperations.FixedTimeEquals(newPassHash, storedPassHash);
        }

        private byte[] GeneratePDFDF2Hash(string password, byte[] salt, int iterations, int hashSize)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA3_512))
            {
                return deriveBytes.GetBytes(hashSize);
            }
        }
    }
}
