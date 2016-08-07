using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Security
{
    /// <summary>
    /// Service for Assymetric Crypt Operations
    /// </summary>
    public class AssymetricCryptService
    {
        private string _privateKey;
        private string _publicKey;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AssymetricCryptService()
        {
            #region keys

            _privateKey = @"<RSAKeyValue>
<Modulus>w8+Wav5rc/AAAMzxiJ79P6QyWE795kSeh2vwQheH1c0wJt+ppKcCUCr7VZhdQBefjjnoDZKn8tXSNT0zWhx338Hi/KIeLHT4BJEK0g7cVl8ybSw7z13TU5LXbmHOzmVi+f4NC8ZKamjGSg//Uj/W3iEDpBPudqNT2uL+jC8jNl0=</Modulus>
<Exponent>AQAB</Exponent>
<P>55eWnoKeSm39HiiMUJIyB4vq0uNO9snxQY3bVUFEiJGBXRlQVkRMF17/WdBAPJewwslZCXQFTMJFR1AGW6JJgw==</P>
<Q>2HKcxsD/SpuuGIKiFVnEu6+Zqo7bCHRPHMxTmDabxx5jpCqGW88nWZ+Eu3EmuLVB5/bWtAbHao6WxJoly+ranw==</Q>
<DP>KgYDureQ6YiTyYkqDOS6V0w4TBQbHAUA1hhbmFjDitR8WNxjC4RRGlyOkUmMnnIYDQBkO6bl30vRLmODA9Wq6Q==</DP>
<DQ>HwCTmhhMuLgBwLr9UkeQWT22qepaTySxrDNMCfJQb73Xkc0Rf5b1UO37SgnT/QLhVMNTT2flKksQJ0rY/RM/iw==</DQ>
<InverseQ>DuqBAQZwPlSCZVoA2D6CQzpi+ApIURa6rQWnKgLplZoX6DxZ/A955AxUuJQtEfO1TUsnJsVgta3UD/BQylnhWw==</InverseQ>
<D>AYYy0yqQmK5K2MXOsJIQQdYBkySUYvhG48BTjORj8J7KxU9msL7dH10Ldyheu5LINUMve/nqigAq+e60aHsD1o7GebpO3N+O9Mv8RE6LftCtmkOqwHWko158YGW/4Xs2aGP5WgsKJthKZJqxGBDfnn9G6Ltdi8WgdHXK6DFH3b8=</D>
</RSAKeyValue>";

            _publicKey = @"<RSAKeyValue>
<Modulus>w8+Wav5rc/AAAMzxiJ79P6QyWE795kSeh2vwQheH1c0wJt+ppKcCUCr7VZhdQBefjjnoDZKn8tXSNT0zWhx338Hi/KIeLHT4BJEK0g7cVl8ybSw7z13TU5LXbmHOzmVi+f4NC8ZKamjGSg//Uj/W3iEDpBPudqNT2uL+jC8jNl0=</Modulus>
<Exponent>AQAB</Exponent>
</RSAKeyValue>";

            #endregion
        }

        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="value"></param>
        public string Encrypt(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            byte[] data = Encoding.UTF8.GetBytes(value);

            byte[] result = Encrypt(data, false);

            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// Encrypts Base64 bytes
        /// </summary>
        public byte[] Encrypt(byte[] value, bool isOAEP)
        {
            RSACryptoServiceProvider provider = CreateCipherForEncryption(_publicKey);

            byte[] encryptedData = provider.Encrypt(value, isOAEP);

            return encryptedData;
        }
        
        /// <summary>
        /// Decrypts Base64 bytes
        /// </summary>
        public byte[] Decrypt(byte[] value, bool isOAEP)
        {
            RSACryptoServiceProvider provider = CreateCipherForEncryption(_privateKey);

            byte[] decryptedData = provider.Decrypt(value, isOAEP);

            return decryptedData;
        }

        /// <summary>
        /// Decrypts string
        /// </summary>
        public string Decrypt(string value)
        {
            byte[] data = Convert.FromBase64String(value);

            byte[] result = Decrypt(data, false);

            return Encoding.UTF8.GetString(result);
        }

        /// <summary>
        /// Get-Keys
        /// </summary>
        public string GetKeys(bool isPrivate)
        {
            RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider();
            RSAParameters publicKey = myRSA.ExportParameters(false);
            return myRSA.ToXmlString(isPrivate);
        }

        private RSACryptoServiceProvider CreateCipherForEncryption(string keys)
        {
            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
            cipher.FromXmlString(keys);

            return cipher;
        }

    }
}
