using NUnit.Framework;
using Vending_Machine_Kata.Classes;
using Vending_Machine_Kata.Models;
using Vending_Machine_Tests.Helpers;

namespace Vending_Machine_Tests
{
    [TestFixture]
    public class CoinReturn_Tests
    {

        private CoinReturns _coinReturns;

        [SetUp]
        public void SetUp()
        {
            _coinReturns = new CoinReturns();
        }

        [TestCase(1.0, 2.0, 1.0)]
        [TestCase(0.5, 0.6, 0.1)]
        [TestCase(0.65, 0.75, 0.1)]
        [TestCase(1.0, 1.2, 0.2)]
        public void CanReturnCorrectChange(decimal cost, decimal balance, decimal change)
        {
            var changeToReturn = _coinReturns.ReturnChangeFromPurchase(cost, balance);

            Assert.AreEqual(change, changeToReturn);
        }
    }
}
