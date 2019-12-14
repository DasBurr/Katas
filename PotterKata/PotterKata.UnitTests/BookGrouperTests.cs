namespace PotterKata.UnitTests
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    using Xunit;

    public class BookGrouperTests
    {
        [Fact]
        public void CanGroupDistinctBooks()
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

            var bookGrouper = new BookGrouper();

            var distinctGroups = bookGrouper.SortBooksIntoDistinctGroups(basket.Books);

            Assert.Equal(2, distinctGroups.Count);
        }

    }
}
