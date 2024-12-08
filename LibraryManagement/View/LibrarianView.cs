﻿using LibraryManagement.Controller;
using LibraryManagement.Model;
using LibraryManagement.Util;
using System;
using System.Collections.Generic;

namespace LibraryManagement.View
{
    internal class LibrarianView
    {

        // Get input to add a new book
        public Book GetNewBookInput()
        {
            Console.WriteLine("Enter Book Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Book Author:");
            string author = Console.ReadLine();

            Console.WriteLine("Enter Book Genre:");
            string genre = Console.ReadLine();

            Console.WriteLine("Enter Publication Date (YYYY-MM-DD):");
            DateTime publicationDate = DateTime.Parse(Console.ReadLine());

            string availabilityInput = "yes";
            bool isAvailable = availabilityInput.ToLower() == "yes";

            return new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                PublicationDate = publicationDate,
                IsAvailable = isAvailable
            };
        }

        public void GetUpdateBookInput(out string bookIdToUpdate, out string newTitle, out string newAuthor, out string newGenre, out bool newAvailability, out DateTime newPublicationDate)
        {
            Console.WriteLine("Enter Book ID to update:");
            bookIdToUpdate = Console.ReadLine();

            Console.WriteLine("Enter New Title:");
            newTitle = Console.ReadLine();

            Console.WriteLine("Enter New Author:");
            newAuthor = Console.ReadLine();

            Console.WriteLine("Enter New Genre:");
            newGenre = Console.ReadLine();

            Console.WriteLine("Enter New Publication Date (YYYY-MM-DD):");
            string date = Console.ReadLine();
            newPublicationDate = Screen.GetValidDate(date);

            Console.WriteLine("Is the book available? (yes/no):");
            string availabilityInput = Console.ReadLine();
            newAvailability = availabilityInput.ToLower() == "yes";
        }

        // Get input to remove a book
        public string GetBookIdForRemoval()
        {
            Console.WriteLine("Enter Book ID to remove:");
            return Console.ReadLine();
        }

        // Get input to search for a book
        public string GetBookIdForSearch()
        {
            Console.WriteLine("Enter Book ID to search:");
            return Console.ReadLine();
        }
        public string GetBorrowerId() {
            Console.WriteLine("Please enter your BookID to see:");
            return Console.ReadLine();
        }

        // Book management menu
        public static void LibrarianMenu(BookControl bookControl, LibrarianView librarianView)
        {
            bool librarianExit = false;
            while (!librarianExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       Book Management Menu         ");
                Console.WriteLine("====================================");
                Console.WriteLine("| 1. Add Book                      |");
                Console.WriteLine("| 2. Update Book                   |");
                Console.WriteLine("| 3. Remove Book                   |");
                Console.WriteLine("| 4. Display All Books             |");
                Console.WriteLine("| 5. Search Book by ID             |");
                Console.WriteLine("| 6. Set Avalability by ID         |");
                Console.WriteLine("| 7. Get BorrowerID                |");
                Console.WriteLine("| 8. Back to Main Menu             |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-8): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Book newBook = librarianView.GetNewBookInput();
                        bookControl.AddBook(newBook);
                        Screen.DisplaySuccessMessage("Book added successfully.");
                        break;

                    case "2":
                        librarianView.GetUpdateBookInput(out string bookId, out string newTitle, out string newAuthor, out string newGenre, out bool newAvailability, out DateTime newPublicationDate);
                        bookControl.UpdateBook(bookId, newTitle, newAuthor, newGenre, newAvailability, newPublicationDate);
                        Screen.DisplaySuccessMessage("Book updated successfully.");
                        break;

                    case "3":
                        string bookIdToRemove = librarianView.GetBookIdForRemoval();
                        bookControl.RemoveBook(bookIdToRemove);
                        Screen.DisplaySuccessMessage("Book removed successfully.");
                        break;

                    case "4":
                        Thread.Sleep(1000);
                        bookControl.DisplayAllBooks();
                        break;

                    case "5":
                        string bookIdToSearch = librarianView.GetBookIdForSearch();
                        bookControl.DisplayBookDetails(bookIdToSearch);
                        break;
                    case "6":
                        Thread.Sleep(1000);
                        bookControl.DisplayAllBooks();
                        string bookIdToSet = librarianView.GetBookIdForSearch();
                        Console.WriteLine("Type yes/no to set Availability: ");
                        string availabilityInput = Console.ReadLine().Trim().ToLower();
                        bool availability = availabilityInput == "yes";
                        bookControl.SetAvailability(bookIdToSet, availability);
                        break;
                    case "7":
                        string booktoSearch = librarianView.GetBorrowerId();
                        bookControl.SearchBookById(booktoSearch);
                        


                        break;
                    case "8":
                        bookControl.WriteToFile();
                        librarianExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}
