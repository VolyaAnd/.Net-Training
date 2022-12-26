using System.Collections.ObjectModel;
using System.Text.RegularExpressions;



namespace NET02._1
{
    public class Book
    {
        private string _isbn;
        private string _title;
        private const int MAX_LENGTH = 1000;
       
        Regex reg1 = new Regex(@"^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$");
        Regex reg2 = new Regex(@"^[0-9]{13}$");

        public DateTime PublicationDate { get; set; }

        public Collection<Author> BookAuthors { get; set; }

        public Book(string isbn, string title, DateTime publicationDate, Collection<Author> bookAuthors)
        {
            ISBN = isbn;
            Title = title;
            PublicationDate = publicationDate;
            BookAuthors = bookAuthors;
        }

        public string ISBN 
        { 
            get
            {
                return isbn;
            }
            set
            {
                if (reg1.IsMatch(value) || reg2.IsMatch(value))
                {
                    isbn = value.Replace("-", "");                   
                }
                else
                    throw new ArgumentException("ISBN must be in form of 'XXX-X-XX-XXXXXX-X' or 'XXXXXXXXXXXXX', where X is the digit of 0...9");
            }
        }
        public string Title 
        { 
            get
            {
                return title;
            }
            set
            {
                if (string.IsNullOrEmpty(value) && value.Length > MAX_LENGTH)
                {
                    throw new ArgumentException("Last Name cannot be empty or greater then 200 chars");
                }
                else
                    title = value;
            }
        }

        
        //isequal  equals - method bool
        public override bool Equals(object book)
        {
            if (book == null || !(book is Book))
                return false;
            return this.ISBN == (book as Book).ISBN;

        }
    }
}
