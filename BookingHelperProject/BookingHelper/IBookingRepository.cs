using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHelperProject
{
        public interface IBookingRepository
        {
            IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
        }
}
