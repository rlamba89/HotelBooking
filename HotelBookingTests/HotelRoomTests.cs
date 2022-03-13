using HotelBooking;
using HotelBooking.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HotelBookingTests
{
    [TestClass]
    public class HotelRoomTests
    {
        private HotelRoom _hotelRoom;

        [TestInitialize]
        public void Initialize()
        {
            _hotelRoom = new HotelRoom(1);
        }

        [DataRow(0)]
        [DataRow(-1)]
        [DataTestMethod]
        public void Constructor_ForInvalidRoomNumber_ShouldThrowInvalidRoomNumberException(int roomNumber)
        {
            Assert.ThrowsException<InvalidRoomNumberException>(() => new HotelRoom(roomNumber));
        }

        [DataRow(10)]
        [DataRow(1)]
        [DataTestMethod]
        public void Constructor_ForValidRoomNumber_ShouldSetRoomNumber(int roomNumber)
        {
            var hotelRoom =  new HotelRoom(roomNumber);

            Assert.AreEqual(roomNumber, hotelRoom.RoomNumber);
        }

        [DataRow("")]
        [DataRow(" ")]
        [DataTestMethod]
        public void Book_ForInvalidGuestName_ShouldThrowInvalidGuestNameException(string guestName)
        {
            Assert.ThrowsException<InvalidGuestNameException>(() => _hotelRoom.Book(guestName, DateTime.Now));
        }

        [TestMethod]
        public void Book_ForNullGuestName_ShouldThrowException()
        {
            Assert.ThrowsException<InvalidGuestNameException>(() => _hotelRoom.Book(null, DateTime.Now));
        }

        [TestMethod]
        public void Book_ForInvalidDateBooking_ShouldThrowInvalidBookingDateException()
        {
            Assert.ThrowsException<InvalidDateException>(() => _hotelRoom.Book("Rahul", DateTime.Now.AddDays(-1)));
        }

        [TestMethod]
        public void Book_ForValidArguments_ShouldSetDetailsCorrectly()
        {
            _hotelRoom.Book("Rahul", DateTime.Now.AddDays(10));

            Assert.AreEqual("Rahul", _hotelRoom.Guest);
            Assert.AreEqual(DateTime.Now.AddDays(10).Date, _hotelRoom.Date.Date);
        }
    }
}
