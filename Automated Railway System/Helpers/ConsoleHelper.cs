using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Helpers
{
    public static class ConsoleHelper
    {
        public static void StationsConsole()
        {
            ThemeHelper.PrintSectionTitle("Available Stations:");
            ThemeHelper.PrintOption("1.Alexandria");
            ThemeHelper.PrintOption("2.Cairo");
            ThemeHelper.PrintOption("3.Luxor");
            ThemeHelper.PrintOption("4.Aswan");
            ThemeHelper.PrintOption("5.Sohag");
            ThemeHelper.PrintOption("6.Qena");
            ThemeHelper.PrintOption("7.Six October");
            ThemeHelper.PrintOption("8.Tanta");
            ThemeHelper.PrintOption("9.Mansoura");
        }
        public static void MainMenu()
        {
            ThemeHelper.PrintHeader("RAILWAY SYSTEM - MAIN MENU");
            ThemeHelper.PrintOption("1. Show All Clients");
            ThemeHelper.PrintOption("2. Show All Tickets");
            ThemeHelper.PrintOption("3. Show All Trains");
            ThemeHelper.PrintOption("4. Show Available Tickets");
            ThemeHelper.PrintOption("5. Client Purchase History");
            ThemeHelper.PrintOption("6. Reserve Ticket");
            ThemeHelper.PrintOption("7. Cancel Ticket");
            ThemeHelper.PrintOption("8. Register New Client");
            Console.WriteLine("--------------------------------------------------------------------");
            ThemeHelper.PrintOption("0. Exit");
            Console.WriteLine("====================================================================");
            Console.WriteLine("Enter your choice: ");
        }
    }
}
