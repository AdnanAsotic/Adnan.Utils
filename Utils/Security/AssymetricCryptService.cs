using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security
{
    public class AssymetricCryptService
    {
        RSACryptoServiceProvider _provider = new RSACryptoServiceProvider();

        public string Encrypt(string value)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(value);

            byte[] result = Encrypt(data, _provider.ExportParameters(false), false);

            return encoding.GetString(result);
        }

        public byte[] Encrypt(byte[] value, RSAParameters rsaInfo, bool isOAEP)
        {
            try
            {
                byte[] encryptedData = null;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(rsaInfo);

                    encryptedData = RSA.Encrypt(value, isOAEP);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public byte[] Decrypt(byte[] value, RSAParameters rsaInfo, bool isOAEP)
        {
            try
            {
                byte[] decryptedData;
  
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(rsaInfo);

                    decryptedData = RSA.Decrypt(value, isOAEP);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }

        public string Decrypt(string value)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(value);

            byte[] result = Decrypt(data, _provider.ExportParameters(true), false);

            return encoding.GetString(result);
        }
    }
}
