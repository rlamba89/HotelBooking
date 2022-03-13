using HotelBooking.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking
{
    public class BookingManager : IBookingManager
    {
        private ConcurrentBag<HotelRoom> _bookedRooms;
        public BookingManager(List<int> hotelRooms)
        {
            if (hotelRooms == null || hotelRooms.Count == 0) throw new InvalidRoomsException();

            HotelRooms = hotelRooms;
            _bookedRooms = new ConcurrentBag<HotelRoom>();
        }

        public List<int> HotelRooms { get; private set; }

        public void AddBooking(string guest, int roomNumber, DateTime date)
        {
            if (!HotelRooms.Any(room => room == roomNumber)) throw new InvalidRoomNumberException("Room number does not exist.");
            if (!IsRoomAvailable(roomNumber, date)) throw new RoomAlreadyBookedException("Room already booked for the same date.");

            _bookedRooms.Add(new HotelRoom(roomNumber).Book(guest, date));   
        }

        public bool IsRoomAvailable(int roomNumber, DateTime date)
        {
            if (!HotelRooms.Any(room => room == roomNumber)) throw new InvalidRoomNumberException("Room number does not exist.");

            return !_bookedRooms.Any(a => a.RoomNumber == roomNumber && a.Date.Date.Equals(date.Date));
        }
        
        public IEnumerable<int> GetAvailableRooms(DateTime date)
        {
            if (date.Date < DateTime.Today) throw new InvalidDateException("Invalid date.");

            return HotelRooms.Except(_bookedRooms.Where(a => a.Date.Date == date.Date).Select(a => a.RoomNumber));
        }
    }
}
