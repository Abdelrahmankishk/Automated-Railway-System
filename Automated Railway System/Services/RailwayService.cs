using Automated_Railway_System.Extentions;
using Automated_Railway_System.Models;
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

        public void HandleRegistration()
        {
            string name = ThemeHelper.Prompt("your name");
            int age = int.Parse(ThemeHelper.Prompt("your age"));
            if (age.IsValidAge() == false)
                throw new ArgumentException("Enter a Valid Age!");
            
            string YearOfBirth = ThemeHelper.Prompt("your Year of Birth (YYYY)");
            if(YearOfBirth.IsValidBirthYear(1900, DateTime.Now.Year) == false)
                throw new ArgumentException("Enter a Valid Year of Birth!");

        }
    }
}
