using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Vending_Machine;
using Vending_Machine_Kata;
using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Tests
{
    [TestFixture]
    public class VendingMachine_Tests
    {
        VendingMachine _vendingMachine;

        [SetUp]
        public void SetUp()
        {
            var vendingMachineStartup = new StartUp();
            var serviceProvider = vendingMachineStartup.ConfigureServices(new ServiceCollection());

            _vendingMachine = new VendingMachine(serviceProvider.GetService<ICoinOperator>(), serviceProvider.GetService<IProductDispenser>(),
                serviceProvider.GetService<IReturnCoinFromSale>(), serviceProvider.GetService<IProductStock>(), serviceProvider.GetService<ICoinBank>());

        }

        [Test]
        public void InsertNickle()
        {
            var result = _vendingMachine.InsertCoin("5", "2");

            Assert.AreEqual("$0.05", result);
        }

        [Test]
        public void InsertDime()
        {
            var result = _vendingMachine.InsertCoin("2", "17");

            Assert.AreEqual("$0.10", result);
        }

        [Test]
        public void InsertQuater()
        {
            var result = _vendingMachine.InsertCoin("5", "24");

            Assert.AreEqual("$0.25", result);
        }

        [Test]
        public void InsertPenny()
        {
            var result = _vendingMachine.InsertCoin("1", "3");

            Assert.AreEqual("Coin returned", result);
        }

        [Test]
        public void PurchaseAffordableProduct()
        {
            _vendingMachine.InsertCoin("5", "24");
            _vendingMachine.InsertCoin("5", "24");
            _vendingMachine.InsertCoin("5", "24");
            _vendingMachine.InsertCoin("5", "24");

            var result = _vendingMachine.SelectProduct("A03");

            Assert.AreEqual("Thank you. $0.00 returned.", result);
        }

        [Test]
        public void TryPurchaseProductWithoutEnoughCredit()
        {
            _vendingMachine.InsertCoin("5", "24");
            _vendingMachine.InsertCoin("5", "24");

            var result = _vendingMachine.SelectProduct("A03");

            Assert.AreEqual("INSERT COIN. $0.50", result);
        }

        [Test]
        public void ReturnInsertedCoins()
        {
            _vendingMachine.InsertCoin("5", "24");
            _vendingMachine.InsertCoin("5", "24");

            var result = _vendingMachine.ReturnCoins();

            Assert.AreEqual("$0.50 returned. INSERT COIN", result);
        }

        [Test]
        public void TryPurchaseSoldOutProduct()
        {
            InsertADollar();
            var purchase1 = _vendingMachine.SelectProduct("A03");
            Assert.AreEqual("Thank you. $0.00 returned.", purchase1);

            InsertADollar();
            var purchase2 = _vendingMachine.SelectProduct("A03");
            Assert.AreEqual("Thank you. $0.00 returned.", purchase2);

            InsertADollar();
            var outOfStock = _vendingMachine.SelectProduct("A03");
            Assert.AreEqual("SOLD OUT", outOfStock);
        }


        private void InsertADollar()
        {
            for (int i = 0; i < 4; i++)
            {
                _vendingMachine.InsertCoin("5", "24");

            }
        }
    }
}
