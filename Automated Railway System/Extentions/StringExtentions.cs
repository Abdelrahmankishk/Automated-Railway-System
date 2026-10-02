using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Automated_Railway_System.Extentions
{
    public static class StringExtentions
    {
        public static string NormalizeID(this string str)
        {
           return str.Trim().ToUpperInvariant() ?? string.Empty;
        }

        /// <summary>
        /// Checks if the string is a valid 4-digit birth year.
        /// </summary>
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

        /// <summary>
        /// Checks if the string is strictly a 2-digit month ("01" through "12").
        /// </summary>
        public static bool IsValidMonthofBirth(this string? input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 2)
                return false;

            return Regex.IsMatch(input, @"^(0[1-9]|1[0-2])$");
        }

        /// <summary>
        /// Checks if the string is strictly a 2-digit day ("01" through "31").
        /// </summary>
        public static bool IsValidDayOfBirth(this string? input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 2)
                return false;

            return Regex.IsMatch(input, @"^(0[1-9]|[12][0-9]|3[01])$");
        }
    }
}
