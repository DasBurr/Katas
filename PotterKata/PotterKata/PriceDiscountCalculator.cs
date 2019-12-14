namespace PotterKata
{
    public class PriceDiscountCalculator
    {
        public decimal TotalDiscountAppliedToDistinctBookCollection(int numberOfBooks, decimal fullPriceOfBooks)
        {
            var discountPercentage = GetDiscountPercentage(numberOfBooks);

            var booksDiscountedPrice = fullPriceOfBooks - (fullPriceOfBooks * discountPercentage);

            return booksDiscountedPrice;
        }

        private static decimal GetDiscountPercentage(int numberOfBooks)
        {
            switch (numberOfBooks)
            {
                case 5: return 0.25m;
                case 4: return 0.20m;
                case 3: return 0.10m;
                case 2: return 0.05m;
                default: return 0;
            }
        }
    }
}
