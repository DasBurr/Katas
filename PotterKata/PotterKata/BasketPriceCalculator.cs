namespace PotterKata
{
    public class BasketPriceCalculator
    {
        private readonly Basket basket;

        private readonly decimal fullProductPrice;

        public BasketPriceCalculator(Basket basket, decimal fullProductPrice)
        {
            this.basket = basket;
            this.fullProductPrice = fullProductPrice;
        }

        public decimal CalculateBasketTotal()
        {
            var basketTotal = 0m;

            var grouper = new BookGrouper();

            var distinctProductGroups = grouper.SortBooksIntoDistinctGroups(this.basket.Books);

            var productDiscounter = new PriceDiscountCalculator();

            foreach (var distinctProductGroup in distinctProductGroups)
            {
                var totalGroupPrice = GetGroupPrice(distinctProductGroup.Count, this.fullProductPrice);

                basketTotal += productDiscounter.TotalDiscountAppliedToDistinctBookCollection(
                     distinctProductGroup.Count,
                     totalGroupPrice);
            }

            return basketTotal;

        }

        private static decimal GetGroupPrice(int groupSize, decimal productPrice) => groupSize * productPrice;
    }
}
