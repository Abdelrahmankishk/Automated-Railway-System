using Automated_Railway_System.Extentions;
using Automated_Railway_System.Helpers;
using Automated_Railway_System.Models;
using Automated_Railway_System.Models.Enums;
using Automated_Railway_System.Services;
using ConsoleTheme;

namespace Automated_Railway_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RailwayStation railwayStation = DataSeeder.SeedData();
            DisplayService displayService = new DisplayService();
            RailwayService railwayService = new(railwayStation, displayService);
            char Choice;

            try
            {
                do
                {
                    ConsoleHelper.MainMenu();

                    bool isValidChoice = char.TryParse(Console.ReadLine(), out Choice);
                    if(Choice  < '0' || Choice > '8' || !isValidChoice)
                    {
                        ThemeHelper.PrintError("Invalid choice. Please enter a valid option.");
                        continue;
                    }
                    switch (Choice)
                    {
                        case '1':
                            displayService.ShowAllClients(railwayStation);
                            break;
                        case '2':
                            displayService.ShowAllTickets(railwayStation);
                            break;
                        case '3':
                            displayService.ShowAllTrains(railwayStation);
                            break;
                        case '4':
                            displayService.ShowAllAvailableTickets(railwayStation);
                            break;
                        case '5':
                            railwayService.HandleClientHistory();
                            break;
                        case '6':
                            railwayService.HandleReservation();
                            break;
                        case '7';
                            railwayService.HandleCancel();
                            break;
                        case '8':
                            railwayService.HandleRegistringClient();
                            break;
                    }
                } while(Choice != '0');
            }
            catch(Exception ex)
            {
                ThemeHelper.PrintError(ex.Message);
            }

        }
    }
}
