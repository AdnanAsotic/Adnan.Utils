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
        UnicodeEncoding _encoding = new UnicodeEncoding();

        public string Encrypt(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            byte[] data = _encoding.GetBytes(value);

            byte[] result = Encrypt(data, false);

            return _encoding.GetString(result);
        }

        public byte[] Encrypt(byte[] value, bool isOAEP)
        {
            byte[] encryptedData = _provider.Encrypt(value, isOAEP);

            return encryptedData;
        }

        public byte[] Decrypt(byte[] value, bool isOAEP)
        {
            byte[] decryptedData = _provider.Decrypt(value, isOAEP);

            return decryptedData;
        }

        public string Decrypt(string value)
        {
            byte[] data = _encoding.GetBytes(value);

            byte[] result = Decrypt(data, false);

            return _encoding.GetString(result);
        }
    }
}
