using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Controller;
using LibraryManagement.Model;
using LibraryManagement.Util;

namespace LibraryManagement.View
{
    internal class StaffView
    {
        private Staff GetNewStaffInput()
        {
            Staff newStaff = new Staff();

            Console.WriteLine("Enter Staff Name:");
            newStaff.Name = Console.ReadLine();

            Console.WriteLine("Enter Staff Age:");
            newStaff.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Staff Gender:");
            newStaff.Gender = Console.ReadLine();

            Console.WriteLine("Enter Staff Date of Birth (YYYY-MM-DD):");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine("Invalid date format. Please enter again (YYYY-MM-DD):");
            }
            newStaff.DateOfBirth = dateOfBirth;

            Console.WriteLine("Enter Staff Address:");
            newStaff.Address = Console.ReadLine();

            Console.WriteLine("Enter Staff Phone Number:");
            newStaff.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Staff Email:");
            newStaff.Email = Console.ReadLine();

            Console.WriteLine("Enter Staff Username:");
            newStaff.Username = Console.ReadLine();

            Console.WriteLine("Enter Staff Password:");
            newStaff.Password = Console.ReadLine();

            return newStaff;
        }

        private void DisplayAllStaffs(List<Staff> staffList)
        {
            if (staffList == null || staffList.Count == 0)
            {
                Console.WriteLine("No staff records found.");
                return;
            }

            Console.WriteLine($"---- List of Staff ----");

            int idWidth = 5;
            int nameWidth = 17;
            int ageWidth = 5;
            int genderWidth = 10;
            int dobWidth = 15;
            int addressWidth = 27;
            int phoneWidth = 15;
            int emailWidth = 25;
            int usernameWidth = 25;

            Console.WriteLine(
                $"{"ID".PadRight(idWidth)}{"Name".PadRight(nameWidth)}{"Age".PadRight(ageWidth)}{"Gender".PadRight(genderWidth)}{"DOB".PadRight(dobWidth)}{"Address".PadRight(addressWidth)}{"Phone Number".PadRight(phoneWidth)}{"Email".PadRight(emailWidth)}{"Username".PadRight(usernameWidth)}"
            );

            foreach (var staff in staffList)
            {
                Console.WriteLine(
                    $"{staff.Id.ToString().PadRight(idWidth)}{staff.Name.PadRight(nameWidth)}{staff.Age.ToString().PadRight(ageWidth)}{staff.Gender.PadRight(genderWidth)}{staff.DateOfBirth.ToString("yyyy-MM-dd").PadRight(dobWidth)}{staff.Address.PadRight(addressWidth)}{staff.PhoneNumber.PadRight(phoneWidth)}{staff.Email.PadRight(emailWidth)}{staff.Username.PadRight(usernameWidth)}"
                );
            }

            Screen.WaitScreen();
        }

        private void DisplayStaffDetails(Staff staff)
        {
            if (staff == null)
            {
                Console.WriteLine("Staff not found.");
                return;
            }

            Console.WriteLine($"---- Staff Details ----");

            int labelWidth = 15;
            int valueWidth = 30;

            Console.WriteLine($"{"ID:".PadRight(labelWidth)}{staff.Id.ToString().PadRight(valueWidth)}");
            Console.WriteLine($"{"Name:".PadRight(labelWidth)}{staff.Name.PadRight(valueWidth)}");
            Console.WriteLine($"{"Age:".PadRight(labelWidth)}{staff.Age.ToString().PadRight(valueWidth)}");
            Console.WriteLine($"{"Gender:".PadRight(labelWidth)}{staff.Gender.PadRight(valueWidth)}");
            Console.WriteLine($"{"Date of Birth:".PadRight(labelWidth)}{staff.DateOfBirth.ToString("yyyy-MM-dd").PadRight(valueWidth)}");
            Console.WriteLine($"{"Address:".PadRight(labelWidth)}{staff.Address.PadRight(valueWidth)}");
            Console.WriteLine($"{"Phone Number:".PadRight(labelWidth)}{staff.PhoneNumber.PadRight(valueWidth)}");
            Console.WriteLine($"{"Email:".PadRight(labelWidth)}{staff.Email.PadRight(valueWidth)}");
            Console.WriteLine($"{"Username:".PadRight(labelWidth)}{staff.Username.PadRight(valueWidth)}");

            Screen.WaitScreen();
        }

        private Librarian GetNewLibrarianInput()
        {
            Librarian librarian = new Librarian();

            Console.WriteLine("Enter Librarian Name:");
            librarian.Name = Console.ReadLine();

            Console.WriteLine("Enter Librarian Age:");
            librarian.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Librarian Gender:");
            librarian.Gender = Console.ReadLine();

            Console.WriteLine("Enter Librarian Date of Birth (YYYY-MM-DD):");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine("Invalid date format. Please enter again (YYYY-MM-DD):");
            }
            librarian.DateOfBirth = dateOfBirth;

            Console.WriteLine("Enter Librarian Address:");
            librarian.Address = Console.ReadLine();

            Console.WriteLine("Enter Librarian Phone Number:");
            librarian.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Librarian Email:");
            librarian.Email = Console.ReadLine();

            Console.WriteLine("Enter Librarian Username:");
            librarian.Username = Console.ReadLine();

            Console.WriteLine("Enter Librarian Password:");
            librarian.Password = Console.ReadLine();

            return librarian;
        }

        private void DisplayAllLibrarians(List<Librarian> librarianList)
        {
            if (librarianList == null || librarianList.Count == 0)
            {
                Console.WriteLine("No librarians found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("---- List of Librarians ----");

            int idWidth = 5;
            int nameWidth = 17;
            int ageWidth = 5;
            int genderWidth = 10;
            int dobWidth = 15;
            int addressWidth = 27;
            int phoneWidth = 15;
            int emailWidth = 25;
            int usernameWidth = 25;

            Console.WriteLine(
                $"{"ID".PadRight(idWidth)}{"Name".PadRight(nameWidth)}{"Age".PadRight(ageWidth)}{"Gender".PadRight(genderWidth)}{"DOB".PadRight(dobWidth)}{"Address".PadRight(addressWidth)}{"Phone Number".PadRight(phoneWidth)}{"Email".PadRight(emailWidth)}{"Username".PadRight(usernameWidth)}"
            );

            foreach (var librarian in librarianList)
            {
                Console.WriteLine(
                    $"{librarian.Id.ToString().PadRight(idWidth)}{librarian.Name.PadRight(nameWidth)}{librarian.Age.ToString().PadRight(ageWidth)}{librarian.Gender.PadRight(genderWidth)}{librarian.DateOfBirth.ToString("yyyy-MM-dd").PadRight(dobWidth)}{librarian.Address.PadRight(addressWidth)}{librarian.PhoneNumber.PadRight(phoneWidth)}{librarian.Email.PadRight(emailWidth)}{librarian.Username.PadRight(usernameWidth)}"
                );
            }

            Screen.WaitScreen();
        }

        private void DisplayLibrarianDetails(Librarian librarian)
        {
            if (librarian == null)
            {
                Console.WriteLine("Librarian not found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("---- Librarian Details ----");

            Console.WriteLine($"ID: {librarian.Id}");
            Console.WriteLine($"Name: {librarian.Name}");
            Console.WriteLine($"Age: {librarian.Age}");
            Console.WriteLine($"Gender: {librarian.Gender}");
            Console.WriteLine($"Date of Birth: {librarian.DateOfBirth:yyyy-MM-dd}");
            Console.WriteLine($"Address: {librarian.Address}");
            Console.WriteLine($"Phone Number: {librarian.PhoneNumber}");
            Console.WriteLine($"Email: {librarian.Email}");
            Console.WriteLine($"Username: {librarian.Username}");

            Screen.WaitScreen();
        }

        private Member GetNewMemberInput()
        {
            Member newMember = new Member();

            Console.WriteLine("Enter Member Name:");
            newMember.Name = Console.ReadLine();

            Console.WriteLine("Enter Member Age:");
            newMember.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Member Gender:");
            newMember.Gender = Console.ReadLine();

            Console.WriteLine("Enter Member Date of Birth (YYYY-MM-DD):");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine("Invalid date format. Please enter again (YYYY-MM-DD):");
            }
            newMember.DateOfBirth = dateOfBirth;

            Console.WriteLine("Enter Member Address:");
            newMember.Address = Console.ReadLine();

            Console.WriteLine("Enter Member Phone Number:");
            newMember.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Member Email:");
            newMember.Email = Console.ReadLine();

            Console.WriteLine("Enter Member Username:");
            newMember.Username = Console.ReadLine();

            Console.WriteLine("Enter Member Password:");
            newMember.Password = Console.ReadLine();

            return newMember;
        }

        private void DisplayAllMembers(List<Member> memberList)
        {
            if (memberList == null || memberList.Count == 0)
            {
                Console.WriteLine("No member records found.");
                return;
            }

            Console.WriteLine($"---- List of Members ----");

            int idWidth = 5;
            int nameWidth = 17;
            int ageWidth = 5;
            int genderWidth = 10;
            int dobWidth = 15;
            int addressWidth = 27;
            int phoneWidth = 15;
            int emailWidth = 25;
            int usernameWidth = 25;

            Console.WriteLine(
                $"{"ID".PadRight(idWidth)}{"Name".PadRight(nameWidth)}{"Age".PadRight(ageWidth)}{"Gender".PadRight(genderWidth)}{"DOB".PadRight(dobWidth)}{"Address".PadRight(addressWidth)}{"Phone Number".PadRight(phoneWidth)}{"Email".PadRight(emailWidth)}{"Username".PadRight(usernameWidth)}"
            );

            foreach (var member in memberList)
            {
                Console.WriteLine(
                    $"{member.Id.ToString().PadRight(idWidth)}{member.Name.PadRight(nameWidth)}{member.Age.ToString().PadRight(ageWidth)}{member.Gender.PadRight(genderWidth)}{member.DateOfBirth.ToString("yyyy-MM-dd").PadRight(dobWidth)}{member.Address.PadRight(addressWidth)}{member.PhoneNumber.PadRight(phoneWidth)}{member.Email.PadRight(emailWidth)}{member.Username.PadRight(usernameWidth)}"
                );
            }

            Screen.WaitScreen();
        }

        private void DisplayMemberDetails(Member member)
        {
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.WriteLine($"---- Member Details ----");

            int labelWidth = 15;
            int valueWidth = 30;

            Console.WriteLine($"{"ID:".PadRight(labelWidth)}{member.Id.ToString().PadRight(valueWidth)}");
            Console.WriteLine($"{"Name:".PadRight(labelWidth)}{member.Name.PadRight(valueWidth)}");
            Console.WriteLine($"{"Age:".PadRight(labelWidth)}{member.Age.ToString().PadRight(valueWidth)}");
            Console.WriteLine($"{"Gender:".PadRight(labelWidth)}{member.Gender.PadRight(valueWidth)}");
            Console.WriteLine($"{"Date of Birth:".PadRight(labelWidth)}{member.DateOfBirth.ToString("yyyy-MM-dd").PadRight(valueWidth)}");
            Console.WriteLine($"{"Address:".PadRight(labelWidth)}{member.Address.PadRight(valueWidth)}");
            Console.WriteLine($"{"Phone Number:".PadRight(labelWidth)}{member.PhoneNumber.PadRight(valueWidth)}");
            Console.WriteLine($"{"Email:".PadRight(labelWidth)}{member.Email.PadRight(valueWidth)}");
            Console.WriteLine($"{"Username:".PadRight(labelWidth)}{member.Username.PadRight(valueWidth)}");

            Screen.WaitScreen();
        }

        public static void StaffMenu(StaffControl staffControl, StaffView staffView, LibrarianControl librarianControl, MemberControl memberControl, string userID)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       Main Management Menu        ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Staff Management              |");
                Console.WriteLine($"| 2. Librarian Management          |");
                Console.WriteLine($"| 3. Member Management             |");
                Console.WriteLine($"| 4. Profile Management            |");
                Console.WriteLine($"| 5. Exit                          |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-5): ");


                string mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        StaffManagement(staffControl, staffView);
                        break;
                    case "2":
                        LibrarianManagement(librarianControl, staffView);
                        break;
                    case "3":
                        MemberManagement(memberControl, staffView);
                        break;
                    case "4":
                        //ProfileManagement(staffView);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public static void StaffManagement(StaffControl staffControl, StaffView staffView)
        {
            bool staffExit = false;
            while (!staffExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("          Staff Management          ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Add Staff                     |");
                Console.WriteLine($"| 2. Update Staff                  |");
                Console.WriteLine($"| 3. Remove Staff                  |");
                Console.WriteLine($"| 4. Display All Staff             |");
                Console.WriteLine($"| 5. Search Staff by ID            |");
                Console.WriteLine($"| 6. Back to Main Menu             |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-6): ");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Staff newStaff = staffView.GetNewStaffInput();
                        staffControl.AddPerson(newStaff);
                        break;

                    case "2":
                        string staffIdToUpdate = Screen.InputId();
                        Staff updateInfo = staffView.GetNewStaffInput();
                        staffControl.UpdatePersonById(staffIdToUpdate, updateInfo);
                        break;

                    case "3":
                        string staffIdToRemove = Screen.InputId();
                        staffControl.RemovePersonById(staffIdToRemove);
                        break;

                    case "4":
                        staffView.DisplayAllStaffs(staffControl.PersonList);
                        break;

                    case "5":
                        string staffIdToSearch = Screen.InputId();
                        staffView.DisplayStaffDetails(staffControl.GetPersonById(staffIdToSearch));
                        break;

                    case "6":
                        staffControl.WriteToFile();
                        staffExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public static void LibrarianManagement(LibrarianControl librarianControl, StaffView staffView)
        {
            bool librarianExit = false;
            while (!librarianExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("      Librarian Management          ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Add Librarian                 |");
                Console.WriteLine($"| 2. Update Librarian              |");
                Console.WriteLine($"| 3. Remove Librarian              |");
                Console.WriteLine($"| 4. Display All Librarians        |");
                Console.WriteLine($"| 5. Search Librarian by ID        |");
                Console.WriteLine($"| 6. Back to Main Menu             |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-6): ");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Librarian newLibrarian = staffView.GetNewLibrarianInput();
                        librarianControl.AddPerson(newLibrarian);
                        break;

                    case "2":
                        string staffIdToUpdate = Screen.InputId();
                        Librarian updateInfo = staffView.GetNewLibrarianInput();
                        librarianControl.UpdatePersonById(staffIdToUpdate, updateInfo);
                        break;

                    case "3":
                        string librarianIdToRemove = Screen.InputId();
                        librarianControl.RemovePersonById(librarianIdToRemove);
                        break;

                    case "4":
                        staffView.DisplayAllLibrarians(librarianControl.PersonList);
                        break;

                    case "5":
                        string searchLibrarianId = Screen.InputId();
                        staffView.DisplayLibrarianDetails(librarianControl.GetPersonById(searchLibrarianId));
                        break;

                    case "6":
                        librarianControl.WriteToFile();
                        librarianExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public static void MemberManagement(MemberControl memberControl, StaffView staffView)
        {
            bool memberExit = false;
            while (!memberExit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("        Member Management           ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Add Member                    |");
                Console.WriteLine($"| 2. Update Member                 |");
                Console.WriteLine($"| 3. Remove Member                 |");
                Console.WriteLine($"| 4. Display All Members           |");
                Console.WriteLine($"| 5. Search Member by ID           |");
                Console.WriteLine($"| 6. Back to Main Menu             |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-6): ");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Member newMember = staffView.GetNewMemberInput();
                        memberControl.AddPerson(newMember);
                        break;

                    case "2":
                        string memberIdToUpdate = Screen.InputId();
                        Member updateInfo = staffView.GetNewMemberInput();
                        memberControl.UpdatePersonById(memberIdToUpdate, updateInfo);
                        break;

                    case "3":
                        string memberIdToRemove = Screen.InputId();
                        memberControl.RemovePersonById(memberIdToRemove);
                        break;

                    case "4":
                        staffView.DisplayAllMembers(memberControl.PersonList);
                        break;

                    case "5":
                        string searchMemberId = Screen.InputId();
                        staffView.DisplayMemberDetails(memberControl.GetPersonById(searchMemberId));
                        break;

                    case "6":
                        memberControl.WriteToFile();
                        memberExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}