using NUnit.Framework;
using Vending_Machine_Kata.Classes;
using Vending_Machine_Kata.Models;
using Vending_Machine_Tests.Helpers;

namespace Vending_Machine_Tests
{
    [TestFixture]
    public class ProductDispenser_Tests
    {
        private ProductDispenser _productDispenser;
        private string _mockCola;
        private string _mockChips;
        private string _mockCandy;

        [SetUp]
        public void SetUp()
        {
            _productDispenser = new ProductDispenser(new ProductFactory(), new ProductValidator());
            _mockCola = Serialiser.SerializeObjectJson(new Product {Code = "A03", Name = "cola", Price = 1.00M, Stock = 2});
            _mockChips = Serialiser.SerializeObjectJson(new Product {Code = "B13", Name = "chips", Price = 0.5M, Stock = 10});
            _mockCandy = Serialiser.SerializeObjectJson(new Product {Code = "E07", Name = "candy", Price = 0.65M, Stock = 20});
        }

        [Test]
       public void RequestForProductsWithTheCorrectBalance()
        {
            var vendedCola = _productDispenser.DispenseBasicProduct("A03", 1.00M);
            var vendedChips = _productDispenser.DispenseBasicProduct("B13", 0.5M);
            var vendedCandy = _productDispenser.DispenseBasicProduct("E07", 0.65M);

            Assert.AreEqual(Serialiser.SerializeObjectJson(vendedCola.Item1), _mockCola);
            Assert.AreEqual(Serialiser.SerializeObjectJson(vendedChips.Item1), _mockChips);
            Assert.AreEqual(Serialiser.SerializeObjectJson(vendedCandy.Item1), _mockCandy);

            Assert.IsTrue(vendedCola.Item2);
            Assert.IsTrue(vendedChips.Item2);
            Assert.IsTrue(vendedCandy.Item2);
        }

       [Test]
       public void RequestForProductsWithTheInCorrectBalance()
       {
           var vendedCola = _productDispenser.DispenseBasicProduct("A03", 0.20M);
           var vendedChips = _productDispenser.DispenseBasicProduct("B13", 0.4M);
           var vendedCandy = _productDispenser.DispenseBasicProduct("E07", 0.5M);

           Assert.IsNull(vendedCola.Item1);
           Assert.IsNull(vendedChips.Item1);
           Assert.IsNull(vendedCandy.Item1);

           Assert.IsFalse(vendedCola.Item2);
           Assert.IsFalse(vendedChips.Item2);
           Assert.IsFalse(vendedCandy.Item2);
       }

    }
}
