namespace PotterKata.UnitTests
{
    using Xunit;

    public class BasketTests
    {
        [Fact]
        public void AddToBasket()
        {
            var basket = new Basket();

            basket.Add(Book.A);

            Assert.Contains(Book.A, basket.Books);
        }
    }
}
