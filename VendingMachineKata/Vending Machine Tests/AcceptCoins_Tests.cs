using NUnit.Framework;
using Vending_Machine_Kata.Classes;

namespace Vending_Machine_Tests
{
    [TestFixture]
    public class AcceptCoins_Tests
    {
        private CoinOperator _coinOperator;

        [SetUp]
        public void SetUp()
        {
            _coinOperator = new CoinOperator(new CoinCalculator());
        }

        [TestCase]
        public void InsertANikle()
        {
            _coinOperator.TakeCoin("5", "2");

            Assert.AreEqual(_coinOperator.Balance, 0.05M);
        }

        [TestCase]
        public void InsertADime()
        {
            _coinOperator.TakeCoin("2", "17");

            Assert.AreEqual(_coinOperator.Balance, 0.10M);
        }

        [TestCase]
        public void InsertAQuater()
        {
            _coinOperator.TakeCoin("5", "24");

            Assert.AreEqual(_coinOperator.Balance, 0.25M);
        }

        [TestCase]
        public void InsertAllCoins()
        {
            _coinOperator.TakeCoin("5", "24");
            _coinOperator.TakeCoin("2", "17");
            _coinOperator.TakeCoin("5", "2");

            Assert.AreEqual(_coinOperator.Balance, 0.40M);
        }

        [TestCase]
        public void InsertAInvalidCoin()
        {
            _coinOperator.TakeCoin("6", "23");

            Assert.AreEqual(_coinOperator.Balance, 0.0M);
            Assert.AreEqual(_coinOperator.ReturnedCoins, 1);
        }

        [TestCase]
        public void InsertAInvalidCoinAndValidCoins()
        {
            _coinOperator.TakeCoin("5", "24");
            _coinOperator.TakeCoin("5", "24");
            _coinOperator.TakeCoin("1", "1");
            _coinOperator.TakeCoin("7", "12");

            Assert.AreEqual(_coinOperator.Balance, 0.5M);
            Assert.AreEqual(_coinOperator.ReturnedCoins, 2);
        }
    }
}
