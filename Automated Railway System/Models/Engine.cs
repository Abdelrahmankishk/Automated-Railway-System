using Automated_Railway_System.Contracts;
using Automated_Railway_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Models
{
    internal class Engine : IDisplayable
    {
        private static int _Counter = 1000;
        const int OilChangeInterval = 20000;
        const int MaintenanceInterval = 100000;

        public Engine(EngineTypes type, int distanceTraveled)
        {
            ID = $"Engine-{++_Counter}";
            Type = type;
            DistanceTraveled = distanceTraveled;
        }
        public Engine() :this (EngineTypes.EMD_JT42CWRM, 10000)
        {

        }

        public string ID { get; init; }
        public EngineTypes Type { get; init; }
        public int DistanceTraveled { get; init; }

        public bool ChecKOil() => DistanceTraveled >= OilChangeInterval && DistanceTraveled <= MaintenanceInterval ? true : false;
        public bool CheckMaintenance() => DistanceTraveled >= MaintenanceInterval ? true : false;

        public string DisplayData()
        {
            string oilStatus = ChecKOil() ? "Oil change required!" : "Oil is GOOD";
            string maintenanceStatus = CheckMaintenance() ? "Maintenance required" : "No Maintenance required";
            return @$"-------------- {ID} ----------------
Engine Type: {Type}
Distance Traveled: {DistanceTraveled} km ({oilStatus}, {maintenanceStatus})
-------------------------------------
";
        }
    }
}
