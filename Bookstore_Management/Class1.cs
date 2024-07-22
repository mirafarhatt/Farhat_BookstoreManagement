using System;
using System.Collections.Generic;
using System.Linq;
namespace Bookstore_Management
{
    internal class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }

        public void AddBook()
        {
            Console.WriteLine("Add the information for the new book:");
            Console.Write("Title: ");
            Title = Console.ReadLine();
            Console.Write("Author name: ");
            Author = Console.ReadLine();
            Console.Write("Description: ");
            Description = Console.ReadLine();
            Console.Write("Price: ");
            string? priceInput = Console.ReadLine();


            if (float.TryParse(priceInput, out float parsedPrice))
            {
                Price = parsedPrice;
            }
            else
            {
                Console.WriteLine("Invalid input for price. Enter a valid one.");
                Console.Write("Price: ");
                Console.Read();
            }
        }

        public static bool IsTitleAvailable(List<Book> books, string title)
        {


            return books.Any(book => book.Title?.Equals(title, StringComparison.OrdinalIgnoreCase) == true);


        }

        public static void ModifyBook(List<Book> books, string title)
        {
            Book? bookToModify = books.FirstOrDefault(b => b.Title == title);

            if (bookToModify == null)
            {
                Console.WriteLine($"Book with title '{title}' not found.");
                return;
            }

            Console.WriteLine($"Modify the information for the book '{bookToModify.Title}':");

            Console.Write($"Current Title: {bookToModify.Title}, New Title: ");
            string? newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                bookToModify.Title = newTitle;
            }

            Console.Write($"Current Author: {bookToModify.Author}, New Author: ");
            string? newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor))
            {
                bookToModify.Author = newAuthor;
            }

            Console.Write($"Current Description: {bookToModify.Description}, New Description: ");
            string? newDescription = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDescription))
            {
                bookToModify.Description = newDescription;
            }

            Console.Write($"Current Price: {bookToModify.Price}, New Price: ");
            if (float.TryParse(Console.ReadLine(), out float newPrice))
            {
                bookToModify.Price = newPrice;
            }
            else
            {
                Console.WriteLine("Invalid input for price. The price will not be changed.");
            }
        }


        public static void ViewBooks(List<Book> books)
        {
            if (!books.Any())
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (var book in books)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Description: {book.Description}, Price: {book.Price}");
            }
        }


        public static void DeleteBook(List<Book> books, string title)
        {
            var book = books.FirstOrDefault(b => b.Title?.Equals(title, StringComparison.OrdinalIgnoreCase) == true);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            books.Remove(book);
            Console.WriteLine("Book deleted successfully.");
        }

    }
}
