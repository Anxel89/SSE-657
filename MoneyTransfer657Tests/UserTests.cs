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
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            User test = new MoneyTransfer657.User();
            Assert.IsInstanceOfType(test, typeof(Object));
        }

        [TestMethod()]
        public void UserTest1()
        {
            User test = new MoneyTransfer657.User("John");
            string name = test.Username;
            Console.WriteLine(name);
            Assert.IsInstanceOfType(test, typeof(Object));
            Assert.AreEqual(name, "John");
            
        }

        [TestMethod()]
        public void Sell_BTCTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            decimal btc_bal = test.Btc;
            test.Sell_BTC(1m);
            Assert.AreEqual(test.Btc,(btc_bal - 1m));          
           
        }

        [TestMethod()]
        public void Buy_BTCTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            decimal btc_bal = test.Btc;
            test.Buy_BTC(1m);
            Assert.AreEqual(test.Btc, (btc_bal + 1m));
        }

        [TestMethod()]
        public void Sell_XRPTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            decimal xrp_bal = test.Xrp;
            test.Sell_XRP(1m);
            Assert.AreEqual(test.Xrp, (xrp_bal - 1m));
        }

        [TestMethod()]
        public void Buy_XRPTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            decimal xrp_bal = test.Xrp;
            test.Buy_XRP(1m);
            Assert.AreEqual(test.Xrp, (xrp_bal + 1m));
        }

        [TestMethod()]
        public void Sell_ETHTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            decimal eth_bal = test.Eth;
            test.Sell_ETH(1m);
            Assert.AreEqual(test.Eth, (eth_bal - 1m));
        }

        [TestMethod()]
        public void Buy_ETHTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            decimal eth_bal = test.Eth;
            test.Buy_ETH(1m);
            Assert.AreEqual(test.Eth, (eth_bal + 1m));
        }

        [TestMethod()]
        public void Update_BalTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            test.Update_Bal();
            Assert.IsNotNull(test);
        }

        [TestMethod()]
        public void Update_DatabaseTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            test.Update_Database();
            Assert.IsNotNull(test);
        }

        [TestMethod()]
        public void Add_Bank_Account_to_DBTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            test.Add_Bank_Account_to_DB("Bank of America", "4568521");
            Assert.IsNotNull(test);
        }

        [TestMethod()]
        public void Add_TransactionTest()
        {
            User test = new MoneyTransfer657.User("Erik Lomas");
            test.Add_Transaction("bob", "bill", "BTC", "1", "pizza");
            Assert.IsNotNull(test);
        }
    }
}