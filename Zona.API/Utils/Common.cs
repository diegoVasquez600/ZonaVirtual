using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Zona.API.Utils
{
    /// <summary>
    /// Class Common
    /// </summary>
    public class Common
    {
        /// <summary>
        /// Creating Random Salt String
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] GetRandomSalt(int length)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            random.GetNonZeroBytes(salt);
            return salt;
        }

        /// <summary>
        /// Creating Password with Salt
        /// </summary>
        public static byte[] SaltHashPassword(byte[] password, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSaltBytes = new byte[password.Length + salt.Length];
            for (int i = 0; i < password.Length; i++)
                plainTextWithSaltBytes[i] = password[i];
            for (int i = 0; i < salt.Length; i++)
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
