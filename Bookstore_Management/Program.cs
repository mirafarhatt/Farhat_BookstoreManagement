using System;
using System.Collections.Generic;
using System.Threading;

namespace Bookstore_Management
{
    internal class MainProgram
    {
        static void Main()
        {
            List<Book> books = new();

            while (true)
            {
                Thread.Sleep(500);
                Console.WriteLine("Welcome to our book store. What would you like to do?");
                Console.WriteLine("1. Add a book");
                Thread.Sleep(700);
                Console.WriteLine("2. Modify the information of a specific book");
                Thread.Sleep(700);
                Console.WriteLine("3. View Books");
                Thread.Sleep(700);
                Console.WriteLine("4. Delete a book");
                Thread.Sleep(700);
                Console.WriteLine("5. Exit");
                Thread.Sleep(500);
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        while (true)
                        {
                            string? yesOrNo;
                            Book newBook = new();
                            newBook.AddBook();
                            books.Add(newBook);
                            Console.WriteLine("Book added successfully.");
                            while (true)
                            {
                                Console.WriteLine("If you want to add another book, write 'yes'; else write 'no': ");
                                yesOrNo = Console.ReadLine()?.Trim().ToLower();

                                if (yesOrNo == "yes" || yesOrNo == "no")
                                {
                                    break;
                                }

                                else
                                {
                                    Console.WriteLine("Invalid input. Please write 'yes' or 'no'.");
                                }
                            }

                            if (yesOrNo == "no")
                            {
                                break;
                            }

                        }

                        break;




                    case "2":
                        Console.WriteLine("Enter the name of the book to modify: ");
                        string? nameEntered = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nameEntered))
                        {
                            Console.WriteLine("Invalid title. Please try again.");
                        }
                        else if (Book.IsTitleAvailable(books, nameEntered))
                        {
                            Book.ModifyBook(books, nameEntered);
                            Console.WriteLine("Modification done successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Title. Please try again.");
                        }
                        break;
                    case "3":
                        Book.ViewBooks(books);
                        break;
                    case "4":
                        Console.Write("Enter the title of the book to delete: ");
                        string? titleToDelete = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(titleToDelete))
                        {
                            Console.WriteLine("Invalid title. Please try again.");
                        }
                        else if (Book.IsTitleAvailable(books, titleToDelete))
                        {
                            Book.DeleteBook(books, titleToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Book not found. Please try again.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Have a nice day! Goodbye :)");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
