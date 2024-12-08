using LibraryManagement.Controller;
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
            Console.ReadKey();
        }
        public static DateTime GetValidDate(string prompt)
        {
            DateTime validDate;

            while (true)
            {

                // Check if the input is in the correct format
                if (DateTime.TryParseExact(prompt, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out validDate))
                {
                    // Additional validation: check if the date is in the future
                    if (validDate <= DateTime.Now)
                    {
                        return validDate; // Return the valid date
                    }
                    else
                    {
                        Console.WriteLine("The date cannot be in the future. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
                }
            }
        }
    }
}
