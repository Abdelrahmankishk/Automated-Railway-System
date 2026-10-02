using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Extentions
{
    public static class IntegerExtentions
    {
        public static bool IsValidAge(this int age)
        {
            return age >= 0 && age <= 120;
        }
    }
}
