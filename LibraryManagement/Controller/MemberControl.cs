using System;
using System.Collections.Generic;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.Controller
{
    internal class MemberControl : PersonControl<Member>
    {
        private readonly string filePath = System.IO.Path.Combine(RelativePath.projectRoot, "TextFiles", "Member.txt");
        public MemberControl() : base()
        { 
            var memberList = ReadMemberFromFile(filePath);
            this.PersonList = memberList;
        }
        public override void AddPerson(Member person)
        {
            base.AddPerson(person);
            person.BookLink = $"{person.Id}-{person.Username}.txt";
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath));
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.WriteAllText(filePath, $"BookLink for {person.BookLink}");
            }
        }
        public void WriteToFile()
        {
            try
            {
                var memberList = PersonList;
                if (memberList == null || memberList.Count == 0)
                {
                    Console.WriteLine("No member data to write to the file.");
                    return;
                }

                // Format the data into a string
                var content = string.Join("\n", memberList.Select(member =>
                    $"{member.Id}:{member.Role}:{member.Name}:{member.Age}:{member.Gender}:" +
                    $"{member.DateOfBirth:MM/dd/yyyy}:{member.Address}:{member.PhoneNumber}:" +
                    $"{member.Email}:{member.Username}:{member.Password}:{member.MembershipStartDate:MM/dd/yyyy}:{member.BookLink}"));

                // Write the data to the file
                System.IO.File.WriteAllText(filePath, content);

                Console.WriteLine("Member data successfully written to the file.");
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
        public List<Member> ReadMemberFromFile(string filePath)
        {
            var memberList = new List<Member>();
            try
            {
                string[] lines = Read_WriteFile.Instance.ReadFile(filePath).Split('\n');
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(':');
                        var member = new Member
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
                            Password = data[10],
                            MembershipStartDate = DateTime.Parse(data[11]),
                            BookLink = data[12].Trim()
                        };
                        string bookPath = System.IO.Path.Combine(RelativePath.projectRoot, "BookFiles", member.BookLink);
                        var borrowedBooks = member.ReadBorrowedBooksFromFile(bookPath);
                        member.BorrowedBooks = borrowedBooks;
                        memberList.Add(member);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading member data from file: {ex.Message}");
            }
            return memberList;
        }
    }
}
