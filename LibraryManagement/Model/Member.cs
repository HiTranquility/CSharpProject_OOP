using LibraryManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Model
{
    internal class Member : Person
    {
        private DateTime membershipStartDate;
        private string bookLink;
        private List<Book> borrowedBooks;

        public DateTime MembershipStartDate { get { return membershipStartDate; } set { this.membershipStartDate = value; } }
        public string BookLink { get { return bookLink; } set { this.bookLink = value; } }
        public List<Book> BorrowedBooks{ get { return borrowedBooks; } set { this.borrowedBooks = value; } }

        public Member()
        {
            this.borrowedBooks = new List<Book>();
        }

        public override string ToString()
        {
            string memberInfo = base.ToString();
            memberInfo += $"Membership Start Date: {MembershipStartDate.ToShortDateString()}\n";
            memberInfo += $"Book Link: {BookLink}\n";
            return memberInfo;
        }

        public void DisplayBorrowedBookDetails()
        {
            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("You have not borrowed any books.");
                return;
            }

            Console.WriteLine("------ Borrowed Books ------");
            Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+");
            Console.WriteLine("| Book ID    | Title                      | Author                    | Genre                     |  Date      |");
            Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+");
            foreach (var book in borrowedBooks)
            {
                Console.WriteLine($"| {book.Id,-10} | {book.Title,-26} | {book.Author,-25} | {book.Genre,-25} | {book.PublicationDate:MM/dd/yyyy} |");
            }
            Console.WriteLine("+------------+----------------------------+---------------------------+---------------------------+------------+");
        }

        public void WriteToFile()
        {
            string filePath = Path.Combine(RelativePath.projectRoot, "BookFiles", BookLink);
            try
            {
                var content = string.Join("\n", borrowedBooks.Select(book =>
                    $"{book.Id},{book.Title},{book.Author},{book.Genre},{book.IsAvailable}," +
                    $"{book.PublicationDate:MM/dd/yyyy}"));

                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing book data to file: {ex.Message}");
            }
        }

        public List<Book> ReadBorrowedBooksFromFile(string filePath)
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
                            PublicationDate = DateTime.Parse(data[4])
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
