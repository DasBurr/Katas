namespace PotterKata.UnitTests
{
    using Xunit;

    public class PriceDiscountCalculaterTests
    {

        [Fact]
        public void CalculateDoubleBookDiscountedPrice()
        {
            var discountedPrice = this.GetDicountedPrice(2, 16m);

            Assert.Equal(15.20m, discountedPrice);
        }

        [Theory]
        [InlineData(30.00, 40.00, 5)]
        [InlineData(25.60, 32.00, 4)]
        [InlineData(21.60, 24.00, 3)]
        public void CalculateAllBookScenarios(decimal expectedPrice, decimal collectionPrice, int numberOfBooks)
        {
            var newDicountedPrice = this.GetDicountedPrice(numberOfBooks, collectionPrice);

            Assert.Equal(expectedPrice, newDicountedPrice);
        }

        private decimal GetDicountedPrice(int numberOfBooks, decimal bookCollectionPrice)
        {
            var discountCalculator = new PriceDiscountCalculator();

            return discountCalculator.TotalDiscountAppliedToDistinctBookCollection(numberOfBooks, bookCollectionPrice);
        }

    }
}
