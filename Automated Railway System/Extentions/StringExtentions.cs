using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Extentions
{
    public static class StringExtentions
    {
        public static string NormalizeID(this string str)
        {
           return str.Trim().ToUpperInvariant() ?? string.Empty;
        }
        public static bool IsValidBirthYear(this string? input, int minYear = 1900, int? maxYear = null)
        {
            // 1. Check null/empty and exact length
            if (string.IsNullOrEmpty(input) || input.Length != 4)
                return false;

            // 2. Ensure all characters are numeric digits
            if (!input.All(char.IsDigit))
                return false;

            // 3. Range check
            int year = int.Parse(input);
            int currentYear = maxYear ?? DateTime.Now.Year;

            return year >= minYear && year <= currentYear;
        }
    }
}
