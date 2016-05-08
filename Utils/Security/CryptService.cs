using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security
{
    /// <summary>
    /// Service for Symmetric encryption / decryption
    /// </summary>
    public class CryptService
    {
        /// <summary>
        /// Encrypts value with specified symmetric algorithm.
        /// </summary>
        /// <example>
        /// <code>
        /// CryptService cs = new CryptService();
        /// string result = cs.Encrypt&lt;AesManaged&gt;("policija", "pass", "salt");
        /// </code>
        /// </example>
        /// <typeparam name="T">Type of Algorithm: AesManaged, Rijndael</typeparam>
        /// <param name="value">Value to encrypt</param>
        /// <param name="password">Password to use for encryption</param>
        /// <param name="salt">Salt to use for encryption</param>
        /// <returns>Base64 encrypted result</returns>
        public string Encrypt<T>(string value, string password, string salt)
            where T : SymmetricAlgorithm, new()
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new T();

            byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

            using (var buffer = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs, Encoding.Unicode))
                {
                    sw.Write(value);
                }

                return Convert.ToBase64String(buffer.ToArray());
            }
        }

        /// <summary>
        /// Decrypts value with specified algorithm.
        /// </summary>
        /// <typeparam name="T">Type of Algorithm: AesManaged, Rijndael</typeparam>
        /// <param name="value">Value to encrypt</param>
        /// <param name="password">Password to use for encryption</param>
        /// <param name="salt">Salt to use for encryption</param>
        /// <returns>Base64 encrypted result</returns>
        public string Decrypt<T>(string text, string password, string salt)
            where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new T();

            byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

            using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
