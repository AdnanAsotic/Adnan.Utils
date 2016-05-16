using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Domain.Seedwork.MSTest.Mocks;

namespace Utils.Domain.Seedwork.MSTest
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void Two_Instantiated_Entities_Should_Not_Be_Equal()
        {
            User user = new User { Name = "Adnan" };
            User user2 = new User { Name = "Maid" };

            Assert.IsFalse(user == user2);
        }
    }
}
