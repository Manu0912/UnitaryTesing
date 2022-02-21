using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHelperProject
{
    public static class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking currentBooking, IBookingRepository bookingRepository)
        {
            if (currentBooking.Status == "Cancelled")
                return string.Empty;

            var activeBookings = bookingRepository.GetActiveBookings(currentBooking.Id);

            var overlappingBooking =
                activeBookings.FirstOrDefault(
                    ab =>
                        currentBooking.ArrivalDate < ab.DepartureDate
                        && ab.ArrivalDate < currentBooking.DepartureDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }
}
