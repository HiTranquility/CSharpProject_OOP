using LibraryManagement.Controller;
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

        public Book GetUpdateBookInput(string bookIdToUpdate)
        {

            Console.WriteLine("Enter New Title:");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Enter New Author:");
            string newAuthor = Console.ReadLine();

            Console.WriteLine("Enter New Genre:");
            string newGenre = Console.ReadLine();

            Console.WriteLine("Enter Member Date of Birth (YYYY-MM-DD):");
            DateTime newPublicationDate;
            while (!DateTime.TryParse(Console.ReadLine(), out newPublicationDate))
            {
                Console.WriteLine("Invalid date format. Please enter again (YYYY-MM-DD):");
            }

            Console.WriteLine("Is the book available? (yes/no):");
            string availabilityInput = Console.ReadLine();
            bool newAvailability = availabilityInput.ToLower() == "yes";

            Book updatedBook = new Book
            {
                Id = bookIdToUpdate,
                Title = newTitle,
                Author = newAuthor,
                Genre = newGenre,
                PublicationDate = newPublicationDate,
                IsAvailable = newAvailability
            };

            return updatedBook;
        }

        public string GetBookIdForRemoval()
        {
            Console.WriteLine("Enter Book ID to remove:");
            return Console.ReadLine();
        }

        public string GetBookIdForSearch()
        {
            Console.WriteLine("Enter Book ID to search:");
            return Console.ReadLine();
        }
        public string GetBorrowerId() {
            Console.WriteLine("Please enter your BookID to see:");
            return Console.ReadLine();
        }

        public static void LibrarianMenu(BookControl bookControl, LibrarianView librarianView, string userID)
        {
            bool librarianExit = false;
            while (!librarianExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("        Book Management Menu        ");
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
                        break;

                    case "2":
                        string bookIdToUpdate = Screen.InputId();
                        Book updateInfo = librarianView.GetUpdateBookInput(bookIdToUpdate);
                        bookControl.UpdateBookbyId(bookIdToUpdate, updateInfo);
                        break;

                    case "3":
                        string bookIdToRemove = librarianView.GetBookIdForRemoval();
                        bookControl.RemoveBookById(bookIdToRemove);
                        break;

                    case "4":
                        bookControl.DisplayAllBooks();
                        break;

                    case "5":
                        string bookIdToSearch = librarianView.GetBookIdForSearch();
                        bookControl.DisplayBookDetails(bookIdToSearch);
                        break;
                    case "6":
                        bookControl.DisplayAllBooks();
                        string bookIdToSet = librarianView.GetBookIdForSearch();
                        bookControl.SetAvailability(bookIdToSet);
                        break;
                    case "7":
                        string borrowerIdtoSearch = librarianView.GetBorrowerId();
                        bookControl.SearchBookByBorrowerId(borrowerIdtoSearch);
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
