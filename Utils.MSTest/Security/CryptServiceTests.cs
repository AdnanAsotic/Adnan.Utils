using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Security;
using System.Security.Cryptography;

namespace Utils.MSTest.Security
{
    [TestClass]
    public class CryptServiceTests
    {
        [TestMethod]
        public void test_should_encrypt_value_policija_with_aesmanaged()
        {
            CryptService cs = new CryptService();
            string result = cs.Encrypt<AesManaged>("policija", "pass", "salt");

            Assert.IsTrue(result.Equals("rNqyzOGSMjBovVU9MAbhu9giW9V+bspo3PKA8Djm9gA="));
        }

        [TestMethod]
        public void test_should_encrypt_value_policija_with_rijndaelmanaged()
        {
            CryptService cs = new CryptService();
            string result = cs.Encrypt<RijndaelManaged>("policija", "pass", "salt");

            System.Diagnostics.Trace.WriteLine("Value: 'policija' was encrypted to : 'rNqyzOGSMjBovVU9MAbhu9giW9V+bspo3PKA8Djm9gA='");

            Assert.IsTrue(result.Equals("rNqyzOGSMjBovVU9MAbhu9giW9V+bspo3PKA8Djm9gA="));
        }

        [TestMethod]
        public void test_should_encrypt_value_policija_with_tripledesprovider()
        {
            CryptService cs = new CryptService();
            string result = cs.Encrypt<TripleDESCryptoServiceProvider>("policija", "pass", "salt");

            Assert.IsTrue(result.Equals("6KJJqibwOd7zqHPx8E92GJbsyc4NMtfh"));
        }

        [TestMethod]
        public void test_should_decrypt_value_with_aesmanaged()
        {
            CryptService cs = new CryptService();
            string result = cs.Decrypt<AesManaged>("rNqyzOGSMjBovVU9MAbhu9giW9V+bspo3PKA8Djm9gA=", "pass", "salt");

            Assert.IsTrue(result.Equals("policija"));
        }
    }
}
