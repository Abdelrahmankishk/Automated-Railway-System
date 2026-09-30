using Automated_Railway_System.Models;
using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Services
{
    public class DisplayService
    {
        public void ShowAllClients(RailwayStation railwayStation)
        {
            if (railwayStation.Clients.Count == 0)
            {
                ThemeHelper.PrintError("No clients Registered!");
                return;
            }
            else
            {
                ThemeHelper.PrintHeader("All Registered Clients:");
                foreach (var client in railwayStation.Clients)
                {
                    Console.WriteLine(client.DisplayData());
                }
            }
        }
        public void ShowAllTickets(RailwayStation railwayStation)
        {
            if (railwayStation.Tickets.Count == 0)
            {
                ThemeHelper.PrintError("No tickets Registered!");
                return;
            }
            else
            {
                ThemeHelper.PrintHeader("All Registered Tickets:");
                foreach (var ticket in railwayStation.Tickets)
                {
                    Console.WriteLine(ticket.DisplayData());
                }
            }
        }
        public void ShowAllTrains(RailwayStation railwayStation)
        {
            if (railwayStation.Trains.Count == 0)
            {
                ThemeHelper.PrintError("No trains Registered!");
                return;
            }
            else
            {
                ThemeHelper.PrintHeader("All Registered Trains:");
                foreach (var train in railwayStation.Trains)
                {
                    Console.WriteLine(train.DisplayData());
                }
            }
        }
        public void ShowAllAvailableTickets(RailwayStation railwayStation)
        {
            if (railwayStation.Tickets.Count == 0)
            {
                ThemeHelper.PrintError("No tickets available!");
                return;
            }
            List<Ticket> AvailableTickets = railwayStation.GetAvailableTickets();
            if (AvailableTickets.Count == 0)
            {
                ThemeHelper.PrintError("No available tickets!");
                return;
            }
            else
            {
                ThemeHelper.PrintHeader("All Available Tickets");
                foreach (var ticket in AvailableTickets)
                {
                    Console.WriteLine(ticket.DisplayData());
                }

            }
        }
        public void ShowClientPurhcaseHistory(Client client)
        {
            if(client== null)
            {
                ThemeHelper.PrintError("Client not found!");
                return;
            }
            Console.WriteLine(client.GetPurchasedTicketsInfo());
        }

        public void ShowTicketReservationSuccess(Ticket ticket, Client client)
        {
            if(ticket == null)
            {
                ThemeHelper.PrintError("Ticket not found!");
                return;
            }
            if(client == null)
            {
                ThemeHelper.PrintError("Client not found!");
                return;
            }
            ThemeHelper.PrintSuccess($"Ticket {ticket.TicketID} has been successfully reserved by Client: {client.Name}.");
            ThemeHelper.PrintSuccess($"Reservation Date: {ticket.ReservationDate?.ToString("dd/MM/yyyy")}");
        }
        public void ShowTicketCancellationSuccess(Ticket ticket)
        {
            if (ticket == null)
            {
                ThemeHelper.PrintError("Ticket not found!");
                return;
            }
            ThemeHelper.PrintSuccess($"Reservation for Ticket {ticket.TicketID} has been successfully canceled");
        }
        public void ShowAddTicketSuccess(Ticket ticket)
        {
            if (ticket == null)
            {
                ThemeHelper.PrintError("Ticket not found!");
                return;
            }
            ThemeHelper.PrintSuccess($"Ticket {ticket.TicketID} has been successfully added to the system.");
        }
    }
}
