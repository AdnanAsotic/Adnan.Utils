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
        [TestMethod]
        public void test_should_encrypt_value_policija_with_rsa()
        {
            string input = "adnan.asotic";
            AssymetricCryptService cs = new AssymetricCryptService();
            string encrypted = cs.Encrypt(input);

            string decrypted = cs.Decrypt(encrypted);

            Assert.IsTrue(decrypted == input);
        }

    }
}
