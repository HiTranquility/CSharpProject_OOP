﻿using System;
using LibraryManagement.Controller;
using LibraryManagement.Model;
using LibraryManagement.Util;
using LibraryManagement.View;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        { 
            StaffControl staffControl = new StaffControl();
            LibrarianControl librarianControl = new LibrarianControl();
            MemberControl memberControl = new MemberControl();
            BookControl bookControl = new BookControl();

            StaffView staffView = new StaffView();
            LibrarianView librarianView = new LibrarianView();
            MemberView memberView = new MemberView();


            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("      Library Management System    ");
                Console.WriteLine("====================================");
                Console.WriteLine($"| 1. Login                         |");
                Console.WriteLine($"| 2. See Credits                   |");
                Console.WriteLine($"| 3. Exit                          |");
                Console.WriteLine("====================================");
                Console.Write("Choose an option (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string userRole;
                        string userID;
                        if (Login(staffControl, librarianControl, memberControl, out userRole, out userID))
                        {
                           
                            if (userRole == "Staff")
                            {
                                StaffView.StaffMenu(staffControl, staffView, librarianControl, memberControl, userID); 
                            }
                            else if (userRole == "Librarian")
                            {
                                LibrarianView.LibrarianMenu(bookControl, librarianView, userID);  
                            }
                            else if (userRole == "Member")
                            {
                                MemberView.MemberMenu(memberControl, bookControl, memberView, userID);  
                            }
                            else break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("╔═══════════════════════════════════════╗");
                        Console.WriteLine("║      Project: Library Management      ║");
                        Console.WriteLine("╚═══════════════════════════════════════╝");
                        Console.ResetColor();
                        Console.WriteLine("Made by:");
                        Console.WriteLine("22110060 - Nguyen Tan Phat");
                        Console.WriteLine("22110051 - Nguyen Huu Nghi");
                        Console.WriteLine("22110009 - Le Cong Bao");
                        Screen.WaitScreen();
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public static bool Login(StaffControl staffControl, LibrarianControl librarianControl, MemberControl memberControl, out string userRole, out string userID)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("               Login                ");
            Console.WriteLine("====================================");
            Console.Write("Please enter your Username: ");
            string username = Console.ReadLine();
            Console.Write("Please enter your Password: ");
            string password = Console.ReadLine();

            Staff staff = staffControl.GetPersonByUsernameAndPassword(username, password);
            if (staff != null)
            {
                userRole = "Staff";
                userID = staffControl.GetIdByUsername(username);
                return true;
            }
            Librarian librarian = librarianControl.GetPersonByUsernameAndPassword(username, password);
            if (librarian != null)
            {
                userRole = "Librarian";
                userID = staffControl.GetIdByUsername(username);
                return true;
            }
            Member member = memberControl.GetPersonByUsernameAndPassword(username, password);
            if (member != null)
            {
                userRole = "Member";
                userID = memberControl.GetIdByUsername(username);
                return true;
            }
            userRole = null;
            userID = null;
            Console.WriteLine("Invalid credentials. Please try again.");
            Screen.WaitScreen();
            return false;
        }
    }
}