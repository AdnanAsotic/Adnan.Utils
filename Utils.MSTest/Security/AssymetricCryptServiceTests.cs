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
        public void test_should_return_input_when_empty_or_null()
        {
            string input = null;

            string encrypted = _cs.Encrypt(input);

            Assert.IsTrue(input == encrypted);
        }

        [TestMethod]
        public void test_should_encrypt_value_with_assymetric_algorithm()
        {
            string input = "adnan.asotic";

            string encrypted = _cs.Encrypt(input);

            Assert.IsTrue(encrypted.Length > 0);
        }

        [TestMethod]
        public void test_should_return_rsa_keys()
        {
            string xml = _cs.GetKeys(false);
        }

        [TestMethod]
        public void test_should_encrypt_and_decrypt_value_with_assymetric_algorithm()
        {
            string input = "adnan";

            string encrypted = _cs.Encrypt(input);
            string decrypted = _cs.Decrypt(encrypted);

            Assert.IsTrue(input.Equals(decrypted));
        }


    }
}
