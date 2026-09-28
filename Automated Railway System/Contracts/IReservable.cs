using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Contracts
{
    internal interface IReservable
    {
        void Reserve();
        void CancelReservation();
        bool IsReserved();
    }
}
