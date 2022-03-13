using HotelBooking.Exceptions;
using System;
namespace HotelBooking
{
    public class HotelRoom 
    {
        public HotelRoom(int roomNumber)
        {
            if (roomNumber < 1) throw new InvalidRoomNumberException();

            RoomNumber = roomNumber;
        }

        public int RoomNumber { get; private set; }

        public DateTime Date { get; private set; }

        public string Guest { get; private set; }

        public HotelRoom Book(string guest, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(guest)) throw new InvalidGuestNameException("Guest name cant not be null or empty.");
            if (date.Date < DateTime.Today) throw new InvalidDateException("Date less than today's date can not be booked.");

            Guest = guest;
            Date = date;

            return this;
        }
    }
}