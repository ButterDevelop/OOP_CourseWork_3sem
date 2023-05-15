using System;
using System.Security.Cryptography;
using System.Text;

namespace OOP_CourseWork.Controls
{
    internal class CryptographyControl
    {
        public readonly static int bytesSize = 96;
        public readonly static int iterationsCount = 10000;

        public static string HashPasswordWithSalt(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var passBytes = Encoding.Unicode.GetBytes(password);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(passBytes, saltBytes, iterationsCount))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(bytesSize));
            }
        }

        public static byte[] GenerateSalt()
        {
            var salt = new byte[bytesSize];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }
    }
}
