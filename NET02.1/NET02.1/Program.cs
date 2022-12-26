using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace NET02._1
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex reg1 = new Regex(@"^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$");
            string str = "012-3-45-678912-3";
            var v = reg1.IsMatch(str);
         
            Author author1 = new Author("Joseph", "Albahari");
            Author author2 = new Author("Ben", "Albahari");
            DateTime publish = new DateTime(2015, 12, 25);
            Collection<Author> bookAuthors = new Collection<Author>();
            bookAuthors.Add(author1);
            bookAuthors.Add(author2);
            
           
            Book book1 = new Book("0123456789123", "C# 9.0 Pocket guide", publish, bookAuthors);
            Book book2 = new Book("0123456789000", "Alice in worderland", publish, bookAuthors);
            Dictionary<string, Book> bookCatalog = new Dictionary<string, Book>();
            bookCatalog.Add(book1.ISBN, book1);
            bookCatalog.Add(book2.ISBN, book2);
            var cat = new Catalog(bookCatalog);
            foreach (Book book in cat)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
