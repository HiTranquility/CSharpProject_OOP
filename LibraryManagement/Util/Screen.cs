using LibraryManagement.Controller;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Util
{
    internal class Screen
    {
        public static void WaitScreen()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        
        public static string InputId()
        {
            Console.WriteLine("Type ID to remove:");
            return Console.ReadLine();
        }

    }
}
