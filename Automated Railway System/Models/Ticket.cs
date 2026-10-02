using Automated_Railway_System.Contracts;
using Automated_Railway_System.Models.Enums;
using System.Globalization;

namespace Automated_Railway_System.Models
{
    public class Ticket : IReservable,IDisplayable
    {
        private static int _Counter = 0;
        public const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        public Ticket( decimal price, Train train, Stations startingStation, Stations destinationStation, TicketStatus status, int Distance = 0,DateTime TravelDate = default!)
        {
            TicketID = $"TICKET-{++_Counter:D3}";
            this.price = price;
            this.train = train;
            StartingStation = startingStation;
            DestinationStation = destinationStation;
            Status = status;
            this.Distance = Distance;
            this.TravelDate = TravelDate;
        }

        public string TicketID { get; init; }
        public decimal price { get; init; }
        public decimal FinalPrice { get; private set; }
        public Train train { get; init; }
        public Client? client { get; private set; }
        public Stations StartingStation { get; init; }
        public Stations DestinationStation { get; init; }
        public TicketStatus Status { get; set; }
        public DateTime? ReservationDate { get; private set; }
        public DateTime TravelDate { get; init; }
        public int? Distance { get; init; }

        public decimal CalculateFinalPrice()
        {
            decimal FinalPrice = price;
            if (client!.IsGolden)
            {
                if (client.DateOfBirth.Month == TravelDate.Month && client.DateOfBirth.Day == TravelDate.Day)
                {
                    FinalPrice = 0; // Free ticket for golden clients on their birthday
                    return FinalPrice;
                }
                if (client.PreferedStation == DestinationStation)
                    FinalPrice *= 0.5m; // 50% discount for golden clients if the destination station is their preferred station
                else
                    FinalPrice *= 0.8m; // 20% discount for golden clients if the destination station is not their preferred station
            }
            if (client.Age > 70)
            {
                FinalPrice *= 0.5m; // 50% discount for clients over 70 years old
            }
            if(client.Pensoiner)
            {
                FinalPrice *= 0.8m; // 20% discount for pensioners
            }
            return FinalPrice;
        }
        public bool IsReserved() => Status == TicketStatus.Reserved;
        public void Reserve(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null!");
            }
            if (IsReserved())
            {
                throw new InvalidOperationException("Ticket is already reserved!");
            }
            this.client = client;
            FinalPrice = CalculateFinalPrice();
            Status = TicketStatus.Reserved;
            ReservationDate = DateTime.Now;
            client.PurchaseTicket(this);
        }

        public void CancelReservation()
        {
            if(client == null)
            {
                throw new InvalidOperationException("Ticket is Not Reserved!");
            }
            if (IsReserved() == false)
            {
                throw new InvalidOperationException("Ticket is Not Reserved!"); 
            }
            this.client = null;
            FinalPrice = 0;
            Status = TicketStatus.Available;
            ReservationDate = default;
        }


        public string DisplayData()
        {
            string clientInfo = client != null ? $"Owned by : {client.Name}, ID: {client.ClientID} - Reserved on {ReservationDate?.ToString(DateFormat)}" : "Not Reserved";
            return $@"------------- {TicketID} -------------
Price: {price:C}
Train: {train.Number} , Train Type: {train.Type}
Travel Date: {TravelDate.ToString(DateFormat, CultureInfo.InvariantCulture)}
Starting Station: {StartingStation}
Destination Station: {DestinationStation}
Total Distance: {Distance} km
Status: {Status}
{clientInfo}
";
        }
    }
}