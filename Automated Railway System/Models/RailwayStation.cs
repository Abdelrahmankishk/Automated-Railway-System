using Automated_Railway_System.Extentions;
using Automated_Railway_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Models
{
    public class RailwayStation
    {
        private readonly List<Client> _clients = new List<Client>();
        private readonly List<Ticket> _tickets = new List<Ticket>();
        private readonly List<Train> _trains = new List<Train>();
        public string Name { get; init; }
        public string PhoneNumber { get; init; }
        public IReadOnlyList<Client> Clients => _clients;
        public IReadOnlyList<Ticket> Tickets => _tickets;
        public IReadOnlyList<Train> Trains => _trains;

        public RailwayStation(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
        
        public Client RegisterClient(string name, int Age,string Address ,bool isPensioner,string DateOfBirth, Stations PreferedStation, int totalCount, int TotalTraveled)
        {
            Client client = new Client(Age, name, Address, isPensioner, DateOfBirth, PreferedStation, totalCount, TotalTraveled);
            _clients.Add(client);
            return client;
        }

        public Client RegisterClient(string name, int Age, string DateOfBirth, Stations PreferedStation, int totalCount, int totalTraveled)
        {
            Client client = new Client(Age, name, DateOfBirth, PreferedStation, totalCount, totalTraveled);
            _clients.Add(client);
            return client;
        }

        public Client RegisterClient(Client client)
        {
            if(client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null.");
            }
            _clients.Add(client);
            return client;
        }

        public void AddTicket (Ticket ticket)
        {
            if(ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null.");
            }
            _tickets.Add(ticket);
        }
        public void AddTrain(Train train)
        {
            if(train == null)
            {
                throw new ArgumentNullException(nameof(train), "Train cannot be null.");
            }
            _trains.Add(train);
            
        }

        public Client FindMember(string ClientID)
        {
            string NormalizedID = ClientID.NormalizeID();
            for(int i = 0; i < _clients.Count; i++)
            {
                if(_clients[i].ClientID == NormalizedID)
                {
                    return _clients[i];
                }
            }
            throw new ArgumentException($"Client with ID {ClientID} not found.", nameof(ClientID));
        }
        public Ticket FindTicket(string TicketID)
        {
            string NormalizedID = TicketID.NormalizeID();
            for(int i = 0; i < _tickets.Count; i++)
            {
                if(_tickets[i].TicketID == NormalizedID)
                {
                    return _tickets[i];
                }
            }
            throw new ArgumentException($"Ticket with ID {TicketID} not found.", nameof(TicketID));
        }

        public List<Ticket> GetAvailableTickets()
        {
            List<Ticket> availableTickets = new List<Ticket>();
            foreach (var ticket in _tickets)
            {
                if (ticket.Status == TicketStatus.Available)
                {
                    availableTickets.Add(ticket);
                }
            }
            return availableTickets;
        }
    }
}
