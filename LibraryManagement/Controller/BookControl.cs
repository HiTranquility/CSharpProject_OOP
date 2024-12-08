using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class BookControl
    {
        private List<Book> bookList;
        private readonly string filePath = System.IO.Path.Combine(RelativePath.projectRoot, "TextFiles", "Book.txt");

        public BookControl()
        {
            var bookList = ReadBookFromFile(filePath);
            this.bookList = bookList;
        }

        private string GenerateNextBookId()
        {
            var existingIds = bookList.Select(b => b.Id)
                                      .Where(id => id.StartsWith("B"))
                                      .Select(id => int.Parse(id.Substring(1))) 
                                      .OrderBy(id => id) 
                                      .ToList();

            
            int nextId = 1; 
            foreach (var id in existingIds)
            {
                if (id != nextId) 
                {
                    break; 
                }
                nextId++; 
            }

            return "B" + nextId.ToString("D3");
        }
        public void AddBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Id))
            {
                book.Id = GenerateNextBookId();
            }

            bookList.Add(book);
            Console.WriteLine($"Book with ID {book.Id} added successfully.");
        }
        public void RemoveBookbyId(string bookId)
        {
            Book bookToRemove = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToRemove != null)
            {
                bookList.Remove(bookToRemove);
            }
        }
        public void UpdateBookbyId(string bookId, Book bookInput)
        {
            Book bookToUpdate = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = bookInput.Title;
                bookToUpdate.Author = bookInput.Author;
                bookToUpdate.Genre = bookInput.Genre;
                bookToUpdate.IsAvailable = bookInput.IsAvailable;
                bookToUpdate.PublicationDate = bookInput.PublicationDate;
            }
        }
        public void DisplayAllBooks()
        {
            Console.Clear();
            Console.WriteLine("------ Borrowed Books ------");
            Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+------------+");
            Console.WriteLine("| Book ID    | Title                      | Author                    | Genre                     | Available  |  Date      |");
            Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+------------+");
            // Looping through the borrowed books and displaying the details in a table format
            foreach (var book in bookList)
            {
                Console.WriteLine($"| {book.Id,-10} | {book.Title,-26} | {book.Author,-25} | {book.Genre,-25} | {(book.IsAvailable ? "Yes" : "No"),-10} | {book.PublicationDate:MM/dd/yyyy} |");
            }
            // Closing the table with a border
            Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+------------+");
            Screen.WaitScreen();
        }
        public void DisplayBookDetails(string BookId)
        {
            var book = bookList.FirstOrDefault(b => b.Id == BookId);
            if (book != null)
            {
                Console.Clear();
                Console.WriteLine("------ Book Details ------");
                Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+------------+");
                Console.WriteLine("| Book ID    | Title                      | Author                    | Genre                     | Available  |  Date      |");
                Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+------------+");
                Console.WriteLine($"| {book.Id,-10} | {book.Title,-26} | {book.Author,-25} | {book.Genre,-25} | {(book.IsAvailable ? "Yes" : "No"),-10} | {book.PublicationDate:MM/dd/yyyy} |");
                Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+------------+");
                Screen.WaitScreen();
            }
            else
            {
                Console.WriteLine($"No book found with ID: {BookId}");
                Screen.WaitScreen();
            }
        }
        public void SearchBookById(string bookId)
        {
            Book book = bookList.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                Console.WriteLine(book.ToString());
            }
        }
        public Book GetBookById(string bookId)
        {
            return bookList.FirstOrDefault(b => b.Id == bookId);
        }
        public bool BorrowBook(string bookId)
        {
            Book bookToBorrow = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToBorrow != null)
            {
                if (bookToBorrow.IsAvailable)
                {
                    bookToBorrow.IsAvailable = false;
                    return true;
                }
            }
            return false;
        }
        public bool ReturnBook(string bookId)
        {
            Book bookToReturn = bookList.FirstOrDefault(b => b.Id == bookId);
            if (bookToReturn != null)
            {
                bookToReturn.IsAvailable = false;
                return true;
            }
            return false;
        }
        public void SetAvailability(string bookId, bool isAvailable)
        {
            // Find the book in the list
            Book bookToUpdate = bookList.FirstOrDefault(b => b.Id == bookId);

            if (bookToUpdate != null)
            {
                // Check if the book is currently borrowed
                if (bookToUpdate.IsAvailable != isAvailable)
                {
                    // Output the borrower's information
                    Console.WriteLine($"The book '{bookToUpdate.Title}' (ID: {bookToUpdate.Id}) is currently borrowed by Member ID: {bookToUpdate.BorrowerId}");
                    if (isAvailable == false && bookToUpdate.BorrowerId == null)
                    {
                        Console.WriteLine("This book can't edit avalibility since no one is borrowing!");
                        Screen.WaitScreen();
                        return;
                    }
                    else
                    {
                        bookToUpdate.IsAvailable = true;
                        Screen.WaitScreen();
                        return;
                    }
                }

                // Update the availability
                bookToUpdate.IsAvailable = isAvailable;
            }
            else
            {
                Console.WriteLine($"No book found with ID: {bookId}");
                Screen.WaitScreen();
            }
        }
        public void WriteToFile()
        {
            try
            {
                var content = string.Join("\n", bookList.Select(book =>
                    $"{book.Id}:{book.Title}:{book.Author}:{book.Genre}:{book.IsAvailable}:{book.PublicationDate:MM/dd/yyyy}"));
                System.IO.File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing book data to file: {ex.Message}");
            }
        }
        public List<Book> ReadBookFromFile(string filePath)
        {
            var bookList = new List<Book>();
            try
            {
                string[] lines = Read_WriteFile.Instance.ReadFile(filePath).Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(':');
                        var book = new Book
                        {
                            Id = data[0],
                            Title = data[1],
                            Author = data[2],
                            Genre = data[3],
                            IsAvailable = bool.Parse(data[4]),
                            PublicationDate = DateTime.Parse(data[5])
                        };
                        bookList.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading book data from file: {ex.Message}");
            }

            return bookList;
        }
    }
}