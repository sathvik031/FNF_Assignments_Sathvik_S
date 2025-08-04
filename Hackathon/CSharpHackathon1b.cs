using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassAssignments
{
    // Entity Layer
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string GetSortableAuthorName()
        {
            if (string.IsNullOrEmpty(Author))
            {
                return string.Empty;
            }

            string[] authors = Author.Split(new string[] { " and ", ", " }, StringSplitOptions.RemoveEmptyEntries);

            if (authors.Length > 0)
            {
                string firstAuthor = authors[0].Trim();
                string[] nameParts = firstAuthor.Split(' ');
                return nameParts.First();
            }
            return string.Empty;
        }

    }

    // Data Layer
    public interface IBookManager
    {
        List<string> SortTitles(List<string> bookEntries);
    }

    public class BookManager : IBookManager
    {
        public List<string> SortTitles(List<string> bookEntries)
        {
            List<Book> books = new List<Book>();

            foreach (string entry in bookEntries)
            {
                int byIndex = entry.LastIndexOf(" by ");

                string titleWithQuotes = entry.Substring(0, byIndex).Trim();
                string author = entry.Substring(byIndex + 4).Trim();

                string title = titleWithQuotes.Trim('"');

                books.Add(new Book(title, author));
            }

            // Sort: Author name -> Title
            var sortedBooks = books.OrderBy(book => book.GetSortableAuthorName())
                                   .ThenBy(book => book.Title)
                                   .ToList();

            List<string> sortedTitles = sortedBooks.Select(book => book.Title).ToList();

            return sortedTitles;
        }
    }

    // UI Layer
    public class UIHandler
    {
        private IBookManager _bookManager;

        public UIHandler(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        public void Run()
        {
            Console.WriteLine("Enter book entries (e.g., \"The Canterbury Tales\" by Chaucer). Enter 'done' to finish.");
            List<string> bookEntries = new List<string>();
            string input;

            Console.Write("Enter book entry: ");
            input = Console.ReadLine();

            while (input.ToLower() != "done")
            {
                bookEntries.Add(input);

                Console.Write("Enter book entry: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("\n--------- Original Book Entries ----------");
            foreach (var entry in bookEntries)
            {
                Console.WriteLine(entry);
            }

            List<string> sortedTitles = _bookManager.SortTitles(bookEntries);

            Console.WriteLine("\n---------- Sorted Book Titles ------------");
            foreach (string title in sortedTitles)
            {
                Console.WriteLine(title);
            }
        }
    }

    // Main Program
    internal class CSharpHackathon1b
    {
        static void Main(string[] args)
        {
            IBookManager bookManager = new BookManager();
            UIHandler uiHandler = new UIHandler(bookManager);
            uiHandler.Run();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}