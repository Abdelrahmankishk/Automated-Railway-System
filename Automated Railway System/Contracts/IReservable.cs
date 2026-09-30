using Automated_Railway_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Railway_System.Contracts
{
    public interface IReservable
    {
        void Reserve(Client client);
        void CancelReservation();
        bool IsReserved();
    }
}
