using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHelperProject
{
    public class BookingRepository
    {
        private readonly UnitOfWork _unitWork;

        public BookingRepository(UnitOfWork unitWork)
        {
            _unitWork = unitWork;
        }

        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
        {
            var bookings =
                    _unitWork.Query<Booking>()
                               .Where(b => b.Id != excludedBookingId && b.Status != "Cancelled");

            if (excludedBookingId.HasValue)
                bookings = bookings.Where(b => b.Id == excludedBookingId.Value);

            return bookings;
        }
    }
}
