using Automated_Railway_System.Contracts;
using Automated_Railway_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Models
{
    public class Client : IDisplayable
    {
        private static int _counter = 100;
        private readonly List<Ticket> _PurchasedTickets = new();
        private string DateFormat = "dd/MM/yyyy";

        public Client(int age, string name, string? address, string dateOfBirth, Stations preferedStation, int travelCount, int totalTraveled)
        {
            ClientID = $"USER-{++_counter:D3}";
            Age = age;
            Name = name;
            Pensoiner = Age > 60 ? true : false;
            Address = address;
            DateOfBirth = DateOnly.ParseExact(dateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            PreferedStation = preferedStation;
            TravelCount = travelCount;
            TotalTraveled = totalTraveled;
        }
        public Client(int age, string name, string dateOfBirth, Stations preferedStation, int travelCount, int totalTraveled) :this(age, name, null, dateOfBirth, preferedStation, travelCount, totalTraveled)
        {
        }
        public string ClientID { get; init; }
        public int Age { get; init; }
        public string Name { get; init; }
        public string? Address { get; set; }
        public bool Pensoiner { get; init; }
        public DateOnly DateOfBirth { get; init; }
        public Stations PreferedStation { get; init; }
        public int TravelCount { get; init; } = 0;
        public int TotalTraveled { get; init; } = 0;
        public IReadOnlyList<Ticket> PurchasedTickets => _PurchasedTickets;

        public bool IsGolden => TravelCount > 50 || TotalTraveled > 10000;   

        public void PurchaseTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null.");
            }
            _PurchasedTickets.Add(ticket);
        }
        public bool IsBirthDay()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return today.Month == DateOfBirth.Month && today.Day == DateOfBirth.Day;
        }
        public string GetPurchasedTicketsInfo()
        {
            if (_PurchasedTickets.Count == 0)
            {
                return "No tickets purchased.";
            }
            var ticketInfo = new StringBuilder();
            ticketInfo.AppendLine($"Purchased Tickets for {Name} (Client ID: {ClientID}):");
            foreach (var ticket in _PurchasedTickets)
            {
                ticketInfo.AppendLine($@"========================= Ticket ID: {ticket.TicketID} =============================
Train: {ticket.train.Number} , Train Type: {ticket.train.Type}
TravelDate: {ticket.TravelDate.ToString(Ticket.DateFormat)}
Reservation Date: { ticket.ReservationDate!.Value.ToString(Ticket.DateFormat, CultureInfo.InvariantCulture)}
Starting Station: {ticket.StartingStation}
Destination Station: {ticket.DestinationStation}
Final Ticket Price: {ticket.FinalPrice}
===========================================================================
");
            }
            return ticketInfo.ToString();
        }
        public string DisplayData()
        {
            string ClientType = IsGolden ? "Golden Client" : "Regular Client";
            string addressInfo = string.IsNullOrEmpty(Address) ? "N/A" : Address;
            string isPensionerInfo = Pensoiner ? "Yes" : "No";
            string isGoldenInfo = IsGolden ? "Yes" : "No";
            return $@" -------------------------- {ClientType} --------------------------
Client ID: {ClientID}
Name: {Name}
Age: {Age} - Pensioner: {isPensionerInfo}
Address: {addressInfo}
Date of Birth: {DateOfBirth.ToString(DateFormat, CultureInfo.InvariantCulture)}
Prefered Station: {PreferedStation}
Is Golden Client: {isGoldenInfo}
Number of Travels: {TravelCount}
Total Distance Traveled: {TotalTraveled} km
Number of Purchased Tickets: {_PurchasedTickets.Count}";
        }
    }
}
