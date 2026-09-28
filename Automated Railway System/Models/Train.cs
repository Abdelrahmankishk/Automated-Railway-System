using Automated_Railway_System.Contracts;
using Automated_Railway_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Models
{
    internal class Train : IDisplayable
    {
        private static int _counter = 100;
        public int Number { get; init; }
        public TrainTypes Type { get; init; }
        public int? MaxSpeed { get; init; }
        public List<TrainServices> Services { get; set; } = new List<TrainServices>();
        private Engine Engine = new();

        public Train(TrainTypes type = TrainTypes.Russian, int? maxSpeed = 0, List<TrainServices> services = default! , Engine engine = default!)
        {
            Number = ++_counter;
            Type = type;
            MaxSpeed = maxSpeed;
            Services = services;
            Engine = engine;
        }
        public string DisplayData()
        {
            string engineData = Engine != null ? Engine.DisplayData() : "No engine data available";
            string SpeedInfo = MaxSpeed.HasValue ? $"MaxSpeed = {MaxSpeed} km/h" : "MaxSpeed not specified";
            string services = Services.Count > 0 ? string.Join(", ", Services) : "No services available";
            return $@"------------- Train Number: {Number} -------------
TrainType = {Type}
{engineData}
Available Services = {services}
{SpeedInfo}
";
        }
    }
}
