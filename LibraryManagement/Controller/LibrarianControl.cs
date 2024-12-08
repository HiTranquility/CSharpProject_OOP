using System;
using System.Collections.Generic;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class LibrarianControl : PersonControl<Librarian>
    {
        string filePath = System.IO.Path.Combine(RelativePath.projectRoot, "TextFiles", "Librarian.txt");
        public LibrarianControl() : base()
        {
            var librarianList = ReadLibrarianFromFile(filePath);
            this.PersonList = librarianList;
        }
        public void WriteToFile()
        {
            try
            {
                var librarianList = PersonList;
                if (librarianList == null || librarianList.Count == 0)
                {
                    Console.WriteLine("No librarian data to write to the file.");
                    return;
                }
                var content = string.Join("\n", librarianList.Select(librarian =>
                    $"{librarian.Id}:{librarian.Role}:{librarian.Name}:{librarian.Age}:{librarian.Gender}:" +
                    $"{librarian.DateOfBirth:MM/dd/yyyy}:{librarian.Address}:{librarian.PhoneNumber}:" +
                    $"{librarian.Email}:{librarian.Username}:{librarian.Password}"));
                System.IO.File.WriteAllText(filePath, content);

                Console.WriteLine("Librarian data successfully written to the file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied. Ensure you have write permissions for the target file.");
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while writing to the file: {ex.Message}");
            }
        }
        public List<Librarian> ReadLibrarianFromFile(string filePath)
        {
            var librarianList = new List<Librarian>();
            try
            {
                string[] lines = Read_WriteFile.Instance.ReadFile(filePath).Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(':');
                        var librarian = new Librarian
                        {
                            Id = data[0],
                            Role = data[1],
                            Name = data[2],
                            Age = int.Parse(data[3]),
                            Gender = data[4],
                            DateOfBirth = DateTime.Parse(data[5]),
                            Address = data[6],
                            PhoneNumber = data[7],
                            Email = data[8],
                            Username = data[9],
                            Password = data[10].Trim()
                        };
                        librarianList.Add(librarian);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading staff data from file: {ex.Message}");
            }

            return librarianList;
        } 
    }
}
