using System;
using System.Collections.Generic;

namespace HotelBooking
{
    public interface IBookingManager
    {
        bool IsRoomAvailable(int room, DateTime date);

        void AddBooking(string guest, int room, DateTime date);

        IEnumerable<int> GetAvailableRooms(DateTime date);
    }
}
