using Automated_Railway_System.Models;
using Automated_Railway_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Helpers
{
    public static class DataSeeder
    {
        public static RailwayStation SeedData()
        {
            // ======= Clients ======================================================================================
            Client client1 = new Client(22, "Abdelrahman Keshk","Smouha, Alexandria","2004-04-25",Stations.Alexandria,25,9000);
            Client client2 = new Client(23, "Omar Hassan", "Gleem, Alexandria", "1999-11-15", Stations.Mansoura, 52, 12000);
            Client client3 = new Client(24, "Mariam El-Sayed", "Maadi, Cairo", "2001-08-03", Stations.Cairo, 10, 15500);
            Client client4 = new Client(71, "Youssef Ibrahim", "Sidi Gaber, Alexandria", "1997-03-22", Stations.luxor, 53, 11000);
            Client client5 = new Client(26, "Nourhan Ali", "Dokki, Giza", "2002-01-10", Stations.Six_October, 12, 14000);

            // ======= Engines ======================================================================================
            Engine engine1 = new Engine(EngineTypes.Henschel_AA22T, 30000);
            Engine engine2 = new Engine(EngineTypes.GE_ES40ACi, 50000);
            Engine engine3 = new Engine(EngineTypes.EMD_JT42CWRM, 150000);

            // ====== Train Services List =================================================================================
            List<TrainServices> trainServices1 = new List<TrainServices>
            {
                TrainServices.Screens,
                TrainServices.WiFi,
                TrainServices.Meal
            };
            // ======= Trains =======================================================================================
            Train train1 = new Train(TrainTypes.Russian, 90, trainServices1, engine1);
            Train train2 = new Train(TrainTypes.Talgo, 120, trainServices1, engine2);
            Train train3 = new Train(TrainTypes.VIP, 100, trainServices1, engine3);
            Train train4 = new Train(TrainTypes.Sleeper, 150, trainServices1, engine1);

            // ======= Tickets =======================================================================================
            Ticket ticket1 = new Ticket(200, train1, Stations.Alexandria, Stations.Cairo, TicketStatus.Available, 300, new DateTime(2027, 04, 25, 20, 30, 0));
            Ticket ticket2 = new Ticket(300, train2, Stations.Cairo, Stations.luxor, TicketStatus.Available, 300, new DateTime(2026, 11, 15, 21, 0, 0));
            Ticket ticket3 = new Ticket(500, train3, Stations.Cairo, Stations.Cairo, TicketStatus.Available, 800, new DateTime(2027, 01, 10, 22, 0, 0));
            Ticket ticket4 = new Ticket(100, train1, Stations.Alexandria, Stations.Tanta, TicketStatus.Available, 120, new DateTime(2026, 12, 01, 12, 30, 0));
            Ticket ticket5 = new Ticket(700, train4, Stations.Cairo, Stations.Aswan, TicketStatus.Available, 1200, new DateTime(2027, 01, 15, 23, 45, 0));
            Ticket ticket6 = new Ticket(200, train2, Stations.Cairo, Stations.Sohag, TicketStatus.Available, 250, new DateTime(2026, 11, 15, 18, 00, 0));

            // ======= Railway Station =================================================================================
            RailwayStation railwayStation = new RailwayStation("Egyptian National Railway Station", "01274422925");

            railwayStation.RegisterClient(client1);
            railwayStation.RegisterClient(client2);
            railwayStation.RegisterClient(client3);
            railwayStation.RegisterClient(client4);
            railwayStation.RegisterClient(client5);

            railwayStation.AddTrain(train1);
            railwayStation.AddTrain(train2);
            railwayStation.AddTrain(train3);
            railwayStation.AddTrain(train4);

            railwayStation.AddTicket(ticket1);
            railwayStation.AddTicket(ticket2);
            railwayStation.AddTicket(ticket3);
            railwayStation.AddTicket(ticket4);
            railwayStation.AddTicket(ticket5);
            railwayStation.AddTicket(ticket6);

            return railwayStation;
        }
    }
}
