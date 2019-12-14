namespace PotterKata
{
    using System.Collections.Generic;

    public class Basket
    {
        private readonly List<Book> books = new List<Book>();

        public void Add(Book book)
        {
            this.books.Add(book);
        }
        public List<Book> Books => this.books;
    }
}
