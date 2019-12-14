namespace PotterKata
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class BookGrouper
    {
        private List<List<Book>> SortedBookGroups = new List<List<Book>>();

        public List<List<Book>> SortBooksIntoDistinctGroups(List<Book> unsortedBooks)
        {
            var distinctGroup = new List<Book>();

            for (int i = unsortedBooks.Count -1; i >= 0; i--)
            {
                var book = unsortedBooks[i];

                if (!distinctGroup.Contains(book))
                {
                    distinctGroup.Add(book);
                    unsortedBooks.RemoveAt(i);
                }
            }

            this.SortedBookGroups.Add(distinctGroup);

            if (unsortedBooks.Count != 0)
            {
                this.SortBooksIntoDistinctGroups(unsortedBooks);
            }

            return this.SortedBookGroups;
        }
    }
}
