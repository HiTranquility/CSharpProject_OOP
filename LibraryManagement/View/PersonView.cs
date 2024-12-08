using LibraryManagement.Model;
using LibraryManagement.Util;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LibraryManagement.View
{
    internal abstract class PersonView<T> where T : Person, new()
    {
        public void DisplayAll(List<T> list)
        {
            Console.WriteLine($"---- List of {typeof(T).Name}s ----");

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

            foreach (var person in list)
            {
                Console.WriteLine(
                    $"{person.Id.ToString().PadRight(idWidth)}{person.Name.PadRight(nameWidth)}{person.Age.ToString().PadRight(ageWidth)}{person.Gender.PadRight(genderWidth)}{person.DateOfBirth.ToString("yyyy-MM-dd").PadRight(dobWidth)}{person.Address.PadRight(addressWidth)}{person.PhoneNumber.PadRight(phoneWidth)}{person.Email.PadRight(emailWidth)}{person.Username.PadRight(usernameWidth)}"
                );
            }

            Screen.WaitScreen();
        }

        public void DisplayDetails(T person)
        {
            if (person != null)
            {
                Console.WriteLine($"---- {typeof(T).Name} Details ----");

                int labelWidth = 15;
                int valueWidth = 30;

                Console.WriteLine($"{"ID:".PadRight(labelWidth)}{person.Id.ToString().PadRight(valueWidth)}");
                Console.WriteLine($"{"Name:".PadRight(labelWidth)}{person.Name.PadRight(valueWidth)}");
                Console.WriteLine($"{"Age:".PadRight(labelWidth)}{person.Age.ToString().PadRight(valueWidth)}");
                Console.WriteLine($"{"Gender:".PadRight(labelWidth)}{person.Gender.PadRight(valueWidth)}");
                Console.WriteLine($"{"Date of Birth:".PadRight(labelWidth)}{person.DateOfBirth.ToString("yyyy-MM-dd").PadRight(valueWidth)}");
                Console.WriteLine($"{"Address:".PadRight(labelWidth)}{person.Address.PadRight(valueWidth)}");
                Console.WriteLine($"{"Phone Number:".PadRight(labelWidth)}{person.PhoneNumber.PadRight(valueWidth)}");
                Console.WriteLine($"{"Email:".PadRight(labelWidth)}{person.Email.PadRight(valueWidth)}");
                Console.WriteLine($"{"Username:".PadRight(labelWidth)}{person.Username.PadRight(valueWidth)}");
            }
            else
            {
                Console.WriteLine($"{typeof(T).Name} not found.");
            }

            Screen.WaitScreen();
        }

        public T GetNewPersonInput()
        {
            Console.WriteLine($"Enter {typeof(T).Name} Name:");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter {typeof(T).Name} Gender:");
            string gender = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Date of Birth (YYYY-MM-DD):");
            string date = Console.ReadLine();
            DateTime dateOfBirth = Screen.GetValidDate(date);

            Console.WriteLine($"Enter {typeof(T).Name} Address:");
            string address = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Email:");
            string email = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Username:");
            string username = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Password:");
            string password = Console.ReadLine();

            return new T
            {
                Name = name,
                Age = age,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                Username = username,
                Password = password
            };
        }

        public T GetUpdatePersonInput(string id)
        {
            Console.WriteLine($"Enter {typeof(T).Name} Name:");
            string name = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter {typeof(T).Name} Gender:");
            string gender = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Date of Birth (YYYY-MM-DD):");
            string date = Console.ReadLine();
            DateTime dateOfBirth = Screen.GetValidDate(date);

            Console.WriteLine($"Enter {typeof(T).Name} Address:");
            string address = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Email:");
            string email = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Username:");
            string username = Console.ReadLine();

            Console.WriteLine($"Enter {typeof(T).Name} Password:");
            string password = Console.ReadLine();

            return new T
            {
                Name = name,
                Age = age,
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                Username = username,
                Password = password
            };
        }

        public string InputId()
        {
            Console.WriteLine("Type ID to remove:");
            return Console.ReadLine();
        }
    }
}
