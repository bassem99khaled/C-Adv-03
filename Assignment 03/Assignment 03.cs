using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace C__Adv_03.Assignment_03
{
    public delegate string BookFunctionDelegate(Book book);

    internal class Assignment_03
    {
        //        2. Considering the Code Below, Write Down the Body of all Listed
        //Methods and Properties ,
        //you need to Define fPtr as the following cases:
        //a.User Defined Delegate Datatype
        //b.BCL Delegates
        //c.Anonymous Method(GetISBN)
        //d.Lambda Expression(GetPublicationDate)
      


                List<Book> books = new List<Book>
        {
            new Book("152556", "C# Programming", new[] { "Author Bassem", "Author Khaled" }, new DateTime(2024, 10, 1), 500),
            new Book("156745", "Advanced C# Programing", new[] { "Author Bassem" }, new DateTime(2025, 1, 26), 999.99m)
        };



        BookFunctionDelegate titleDelegate = new BookFunctionDelegate(BookFunctions.GetTitle);
        
       
       
        Func<Book, string> authorsDelegate = BookFunctions.GetAuthors;

                
                Func<Book, string> isbnDelegate = delegate (Book b)
                {
                    return $"ISBN: {b.ISBN}";
                };

             
       Func<Book, string> publicationDateDelegate =( b ) => b.PublicationDate.ToShortDateString();


    }

    public class Book
    {
        #region Property
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Constructor
        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}," +
                $" Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
        }

        #endregion
    }

    public class BookFunctions
    {
        #region Method
        public static string GetTitle(Book B)
        {
            return B.Title;
        }


        public static string GetAuthors(Book B)
        {
            return string.Join(", ", B.Authors);
        }


        public static string GetPrice(Book B)
        {
            return $"Price Of Book: {B.Price:C}";
        }
        #endregion
    }

    public class LibraryEngine
    {
        #region Method
        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
        #endregion
    }


}
