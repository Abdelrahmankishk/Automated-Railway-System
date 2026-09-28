using Automated_Railway_System.Contracts;

namespace Automated_Railway_System.Models
{
    internal class Ticket : IReservable,IDisplayable
    {
        public void CancelReservation()
        {
            throw new NotImplementedException();
        }

        public string DisplayData()
        {
            throw new NotImplementedException();
        }

        public bool IsReserved()
        {
            throw new NotImplementedException();
        }

        public void Reserve()
        {
            throw new NotImplementedException();
        }
    }
}