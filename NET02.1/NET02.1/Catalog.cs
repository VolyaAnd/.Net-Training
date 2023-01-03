using System.Collections;


namespace NET02._1
{
    public class Catalog : IEnumerable<Book>
    {
        public Dictionary<string, Book> BookCatalog { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public IEnumerator<Book> GetEnumerator()
        {
            var sortedDict = from entry in BookCatalog orderby entry.Value.Title ascending select entry.Value;  //AS EXAMPLE
            return (IEnumerator<Book>)sortedDict.GetEnumerator();
        }

        public Catalog(Dictionary<string, Book> catalog)
        {
            BookCatalog = catalog;
        }
        //Get a set of books for a given author's first and last name (ignore register)
        public IEnumerator<Book> GetAuthorsBooks(Author author)
        {
            var sortedBooks = from entry in BookCatalog where entry.Value.BookAuthors.Contains(author) select entry.Value;  
            return (IEnumerator<Book>)sortedBooks.GetEnumerator();
        }
        
        public IEnumerator<Book> GetSortedByPublicationDate()
        {
            var sortedByDate = from entry in BookCatalog orderby entry.Value.PublicationDate descending select entry.Value;  
            return (IEnumerator<Book>)sortedByDate.GetEnumerator();
        }

        //Get a set of two-items tuples of the form "author - the number of his/her books in the catalog".

        public IEnumerator<Book> GetNumberOfAuthorsBooks()
        {
            var AuthorAndBooks = from entry in BookCatalog
                                 group entry by entry.Value.BookAuthors into g
                                 select new { BookCount = g.Count() }; ;
            return (IEnumerator<Book>)AuthorAndBooks.GetEnumerator();
        }


    }
}
