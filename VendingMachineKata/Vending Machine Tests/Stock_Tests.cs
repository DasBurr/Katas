using NUnit.Framework;
using Vending_Machine_Kata.Classes;
using Vending_Machine_Kata.Models;

namespace Vending_Machine_Tests
{
    [TestFixture]
    public class Stock_Tests
    {
        private ProductStock _stockChecker;

        [SetUp]
        public void SetUp()
        {
            _stockChecker = new ProductStock(new ProductFactory());
        }

        [Test]
        public void GivenIBuyTwoProductsWithAStockCountOfFive()
        {
            var product = new Product {Code = "ABC", Name = "test", Price = 1.0M, Stock = 5};

            _stockChecker.DecreaseStock(product);
            _stockChecker.DecreaseStock(product);

            Assert.AreEqual(product.Stock, 3);
        }

        [Test]
        public void GivenIBuyOneProductsWithAStockCountOfOne()
        {
            var product = new Product { Code = "ABC", Name = "test", Price = 1.0M, Stock = 1 };

            _stockChecker.DecreaseStock(product);

            Assert.AreEqual(product.Stock, 0);
        }
    }
}
