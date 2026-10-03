using Automated_Railway_System.Extentions;
using Automated_Railway_System.Helpers;
using Automated_Railway_System.Models;
using Automated_Railway_System.Models.Enums;
using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Services
{
    public class RailwayService
    {
        private readonly RailwayStation _railwayStation;
        private readonly DisplayService _displayService;
        public RailwayService(RailwayStation railwayStation, DisplayService displayService)
        {
            _railwayStation = railwayStation;
            _displayService = displayService;
        }

        public void HandleRegistringClient()
        {
            string name = ThemeHelper.Prompt("your name");
            int age = int.Parse(ThemeHelper.Prompt("your age"));
            if (age.IsValidAge() == false)
                throw new ArgumentException("Enter a Valid Age!");

            string YearOfBirth = ThemeHelper.Prompt("your Year of Birth (YYYY)");
            if (YearOfBirth.IsValidBirthYear(1900, DateTime.Now.Year) == false)
                throw new ArgumentException("Enter a Valid Year of Birth!");

            string MonthOfBirth = ThemeHelper.Prompt("your Month of Birth (MM)");
            if (MonthOfBirth.IsValidMonthofBirth() == false)
                throw new ArgumentException("Enter a Valid Month of Birth!");

            string DayOfBirth = ThemeHelper.Prompt("your Day of Birth (DD)");
            if (DayOfBirth.IsValidDayOfBirth() == false)
                throw new ArgumentException("Enter a Valid Day of Birth!");

            string dateOfBirth = $"{YearOfBirth:D4}-{MonthOfBirth:D2}-{DayOfBirth:D2}";

            string address = ThemeHelper.Prompt("your Home address");

            ConsoleHelper.StationsConsole();
            int StationChoice = int.Parse(ThemeHelper.Prompt("your preferred station"));
            if (StationChoice < 1 || StationChoice > 9)
                throw new ArgumentException("Enter a Valid Station Choice!");
            Stations PreferedStation = Stations.Alexandria;
            switch (StationChoice)
            {
                case 1:
                    PreferedStation = Stations.Alexandria;
                    break;
                case 2:
                    PreferedStation = Stations.Cairo;
                    break;
                case 3:
                    PreferedStation = Stations.luxor;
                    break;
                case 4:
                    PreferedStation = Stations.Aswan;
                    break;
                case 5:
                    PreferedStation = Stations.Sohag;
                    break;
                case 6:
                    PreferedStation = Stations.Qena;
                    break;
                case 7:
                    PreferedStation = Stations.Six_October;
                    break;
                case 8:
                    PreferedStation = Stations.Tanta;
                    break;
                case 9:
                    PreferedStation = Stations.Mansoura;
                    break;
            }

            Client newClient = new Client(age, name, address, dateOfBirth, PreferedStation, 0, 0);

            _railwayStation.RegisterClient(newClient); 
            _displayService.ShowAddClientSuccess(newClient);
        }

        public void HandleCancel()
        {
            string TicketID = ThemeHelper.Prompt("Ticket ID u want to cancel").NormalizeID();
            Ticket canceledticket = _railwayStation.FindTicket(TicketID);

            canceledticket.CancelReservation();
            _displayService.ShowTicketCancellationSuccess(canceledticket);
            
            Ticket ReturnAvailableTicket = new Ticket(canceledticket.price, canceledticket.train, canceledticket.StartingStation,canceledticket.DestinationStation, TicketStatus.Available,canceledticket.Distance ?? 0, canceledticket.TravelDate);
            _railwayStation.AddTicket(ReturnAvailableTicket);
        }

        public void HandleClientHistory()
        {
            string ClientID = ThemeHelper.Prompt("Client ID").NormalizeID();
            Client client = _railwayStation.FindMember(ClientID);
            _displayService.ShowClientPurhcaseHistory(client);
        }

        public void HandleReservation() { 
            string ClientID = ThemeHelper.Prompt("Client ID").NormalizeID();
            Client client = _railwayStation.FindMember(ClientID);

            _displayService.ShowAllAvailableTickets(_railwayStation);

            string TicketID = ThemeHelper.Prompt("Ticket ID u want to reserve").NormalizeID();
            Ticket ticket = _railwayStation.FindTicket(TicketID);

            ticket.Reserve(client);
            _displayService.ShowTicketReservationSuccess(ticket, client);
        }
    }
}
