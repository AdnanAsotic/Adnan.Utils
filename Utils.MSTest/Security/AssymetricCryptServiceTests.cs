using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Security;

namespace Utils.MSTest.Security
{
    [TestClass]
    public class AssymetricCryptServiceTests
    {
        AssymetricCryptService _cs = new AssymetricCryptService();

        [TestMethod]
        public void encrypting_null_should_return_null()
        {
            string input = null;

            string encrypted = _cs.Encrypt(input);

            Assert.IsTrue(input == encrypted);
        }

        [TestMethod]
        public void encrypting_value_should_return_different_value()
        {
            string input = "adnan.asotic";

            string encrypted = _cs.Encrypt(input);

            Assert.IsTrue(encrypted.Length > 0);
        }

        [TestMethod]
        public void decrypting_should_return_encrypted_value()
        {
            string input = "adnan";

            string encrypted = _cs.Encrypt(input);
            string decrypted = _cs.Decrypt(encrypted);

            Assert.IsTrue(input.Equals(decrypted));
        }


    }
}
