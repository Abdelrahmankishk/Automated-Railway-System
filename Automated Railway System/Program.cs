using Automated_Railway_System.Extentions;
using Automated_Railway_System.Helpers;
using Automated_Railway_System.Models.Enums;
using ConsoleTheme;

namespace Automated_Railway_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Automated Railway System");
            ConsoleHelper.StationsConsole();
            int StationChoice = int.Parse(ThemeHelper.Prompt("your preferred station)"));
            if (StationChoice < 1 || StationChoice > 9)
                throw new ArgumentException("Enter a Valid Station Choice!");
        }
    }
}
