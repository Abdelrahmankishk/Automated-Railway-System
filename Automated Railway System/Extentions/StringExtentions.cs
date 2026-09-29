using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Extentions
{
    internal static class StringExtentions
    {
        public static string NormalizeID(this string str)
        {
           return str.Trim().ToUpperInvariant() ?? string.Empty;
        }
    }
}
