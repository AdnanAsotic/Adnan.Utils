using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Domain.Seedwork.MSTest.Mocks;

namespace Utils.Domain.Seedwork.MSTest
{
    [TestClass]
    public class ValueObjectTests
    {
        [TestMethod]
        public void Test_Equality_Between_ValueObjects()
        {
            Address address = new Address { Street = "Poligonska 21" };
            Address address2 = new Address { Street = "Poligonska 21" };

            Assert.IsTrue(address == address2);
        }

        [TestMethod]
        public void Test_Not_Equality_Between_ValueObjects()
        {
            Address address = new Address { Street = "Poligonska 22" };
            Address address2 = new Address { Street = "Poligonska 21" };

            Assert.IsFalse(address == address2);
        }
    }
}
