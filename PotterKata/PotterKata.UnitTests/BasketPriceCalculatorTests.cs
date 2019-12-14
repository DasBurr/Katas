namespace PotterKata.UnitTests
{
    using Xunit;

    public class BasketPriceCalculatorTests
    {
        [Fact]
        public void CalculatorSumsRightAmountOnSingleDistinctGroupOfBooks()
        {
            var basket = new Basket();
            basket.Add(Book.A);
            basket.Add(Book.B);
            basket.Add(Book.C);
            basket.Add(Book.D);
            basket.Add(Book.E);

            var basketCalculator = new BasketPriceCalculator(basket, 8m);

            var discountedBasketTotal = basketCalculator.CalculateBasketTotal();

            Assert.Equal(30m, discountedBasketTotal);
        }

        [Fact]
        public void CalculatorSumsRightAmountOnDoubleDistinctGroupOfBooks()
        {
            var basket = new Basket();
            basket.Add(Book.A);
            basket.Add(Book.A);
            basket.Add(Book.B);
            basket.Add(Book.B);
            basket.Add(Book.C);
            basket.Add(Book.C);
            basket.Add(Book.D);
            basket.Add(Book.E);

            var basketCalculator = new BasketPriceCalculator(basket, 8m);

            var discountedBasketTotal = basketCalculator.CalculateBasketTotal();

            Assert.Equal(51.60m, discountedBasketTotal);
        }

        [Fact]
        public void CalculatorSumsRightAmountOnSingleBook()
        {
            var basket = new Basket();
            basket.Add(Book.A);

            var basketCalculator = new BasketPriceCalculator(basket, 8m);

            var discountedBasketTotal = basketCalculator.CalculateBasketTotal();

            Assert.Equal(8m, discountedBasketTotal);
        }
    }
}
