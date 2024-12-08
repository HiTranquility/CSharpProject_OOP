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
    internal class StaffView : PersonView <Staff>
    {
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
                Console.WriteLine("       Staff Management             ");
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
                        Staff newStaff = staffView.GetNewPersonInput();
                        staffControl.AddPerson(newStaff);
                        break;

                    case "2":
                        string staffIdToUpdate = staffView.InputId();
                        Staff updateInfo = staffView.GetNewPersonInput();
                        staffControl.UpdatePersonById(staffIdToUpdate, updateInfo);
                        break;

                    case "3":
                        string staffIdToRemove = staffView.InputId();
                        staffControl.RemovePersonById(staffIdToRemove);
                        break;

                    case "4":
                        staffView.DisplayAll(staffControl.PersonList);
                        break;

                    case "5":
                        string staffIdToSearch = staffView.InputId();
                        staffView.DisplayDetails(staffControl.GetPersonById(staffIdToSearch));
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
                        Librarian newLibrarian = staffView.GetNewPersonInput();
                        librarianControl.AddPerson(newLibrarian);
                        break;

                    case "2":
                        // Update Librarian (Get all update details)
                        staffView.GetUpdateLibrarianInput(out string librarianId);
                        librarianControl.UpdatePersonById(librarianId);
                        Screen.DisplaySuccessMessage("Librarian updated successfully.");
                        break;

                    case "3":
                        // Remove Librarian
                        Console.WriteLine("Enter Librarian ID to remove:");
                        string librarianIdToRemove = Console.ReadLine();
                        librarianControl.RemovePersonById(librarianIdToRemove);
                        Screen.DisplaySuccessMessage("Librarian removed successfully.");
                        break;

                    case "4":
                        // Display all Librarians
                        staffView.DisplayAllLibrarian(librarianControl.GetPersonList());
                        break;

                    case "5":
                        // Search Librarian by ID
                        Console.WriteLine("Enter Librarian ID to search:");
                        string searchLibrarianId = Console.ReadLine();
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
                        Screen.DisplaySuccessMessage("Member added successfully.");
                        break;

                    case "2":
                        Console.WriteLine("Enter Member ID and new membership level:");
                        staffView.GetUpdateMemberInput(out string memberId);
                        memberControl.UpdatePersonById(memberId);
                        Screen.DisplaySuccessMessage("Member updated successfully.");
                        break;

                    case "3":
                        Console.WriteLine("Enter Member ID to remove:");
                        string memberIdToRemove = Console.ReadLine();
                        memberControl.RemovePersonById(memberIdToRemove);
                        Screen.DisplaySuccessMessage("Member removed successfully.");
                        break;

                    case "4":
                        staffView.DisplayAllMembers(memberControl.GetPersonList());
                        break;

                    case "5":
                        Console.WriteLine("Enter Member ID to search:");
                        string searchMemberId = Console.ReadLine();
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