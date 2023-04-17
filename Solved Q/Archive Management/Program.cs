using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive_Management
{
    internal class Program
    {
        public static SortedDictionary<int, Book> bookDetails = new SortedDictionary<int, Book>();

        public SortedDictionary<string,List<Book>> GroupBooksByGenre()
        {
            List<string> genreList = new List<string>();
            foreach(var val in bookDetails.Values)
            {
                if (!genreList.Contains(val.Genre))
                {
                    genreList.Add(val.Genre);
                }
            }
            SortedDictionary<string, List<Book>> results = new SortedDictionary<string, List<Book>>();
            foreach(var gen in genreList)
            {
                List<Book> genBooks = new List<Book>();
                foreach (var book in bookDetails.Values)
                {
                    if(book.Genre == gen)
                    {
                        genBooks.Add(book);
                    }
                }
                results.Add(gen, genBooks);
            }
            return results;
        }

        public Dictionary<string, double> UpdatePenaltyAmount(double amount)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            foreach (var val in bookDetails.Values)
            {
                DateTime iDate = DateTime.ParseExact(val.IssueDate, "MM/dd/yyyy", null);
                DateTime rDate = DateTime.ParseExact(val.ReturnDate, "MM/dd/yyyy", null);
                TimeSpan diff = rDate - iDate;
                if(diff.Days > 3)
                {
                    result.Add(val.MemberID, amount);
                }
            }
            return result;
        }

        public List<string> FindBooksNameWithSameDayReturn()
        {
            List<string> results = new List<string>();
            foreach (var val in bookDetails.Values)
            {
                DateTime iDate = DateTime.ParseExact(val.IssueDate, "MM/dd/yyyy", null);
                DateTime rDate = DateTime.ParseExact(val.ReturnDate, "MM/dd/yyyy", null);
                if(DateTime.Compare(iDate, rDate) == 0)
                {
                    results.Add(val.Name);
                }
                
            }
            return results;
        }

        static void Main(string[] args)
        {
            bookDetails.Add(1, new Book("M01", "The Stranger", "Adventure", "04/25/2020", "05/01/2020", 0));
            bookDetails.Add(2, new Book("M02", "War and Peace", "Historical", "07/15/2008", "07/15/2008", 0));
            bookDetails.Add(3, new Book("M03", "Odyssey", "Adventure", "10/25/2003", "10/25/2003", 0));
            bookDetails.Add(4, new Book("M04", "The Hobbit", "Fantasy", "11/08/2020", "11/13/2020", 0));
            bookDetails.Add(5, new Book("M05", "The Alchemist", "Fantasy", "02/09/2020", "02/10/2020", 0));

            Program main = new Program();

            while (true)
            {
                Console.WriteLine("1. Group books by genre");
                Console.WriteLine("2. Update penalty amount");
                Console.WriteLine("3. Find same day return books");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice");
                switch (Convert.ToInt32(Console.ReadLine())) 
                {
                    case 1:
                        foreach(var val in main.GroupBooksByGenre())
                        {
                            Console.WriteLine(val.Key);
                            foreach(var book in val.Value)
                            {
                                Console.WriteLine(book.Name);
                            }
                            Console.WriteLine();
                        }
                        
                        break;

                    case 2:
                        Console.WriteLine("Enter penalty amount");
                        double input = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("MemberID\tPenalty");

                        foreach (var val in main.UpdatePenaltyAmount(input))
                        {
                            Console.WriteLine($"{val.Key}\t{val.Value}");
                        }
                        break;

                    case 3:
                        foreach (var val in main.FindBooksNameWithSameDayReturn())
                        {
                            Console.WriteLine(val);
                        }
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }
            }
        }
    }
}
