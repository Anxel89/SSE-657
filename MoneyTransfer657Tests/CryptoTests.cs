using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyTransfer657;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer657.Tests
{
    [TestClass()]
    public class CryptoTests
    {
        [TestMethod()]
        public void CryptoTest()
        {
            Crypto test = new MoneyTransfer657.Crypto();
            Assert.IsInstanceOfType(test, typeof(Object));
        }

        [TestMethod()]
        public void CryptoTest1()
        {
            Crypto test = new MoneyTransfer657.Crypto("BTC");
            Assert.AreEqual(test.Name,"BTC");
        }
    }
}