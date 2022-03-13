using HotelBooking;
using HotelBooking.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingTests
{
    [TestClass]
    public class BookingManagerTests
    {
        private List<int> totalRooms;
        private BookingManager bookingManager;

        [TestInitialize]
        public void Initialize()
        {
            totalRooms = new List<int>
            {
                101,
                102,
                103,
                104
            };

            bookingManager = new BookingManager(totalRooms);
        }

        [TestMethod]
        public void Constructor_ForNonEmptyRoomsList_ShouldInitializeAvailableRooms()
        {
            Assert.AreEqual(totalRooms.Count, bookingManager.HotelRooms.Count);
        }

        [TestMethod]
        public void Constructor_ForNullRoomsList_ShouldThrowRoomsInvalidException()
        {
            Assert.ThrowsException<InvalidRoomsException>(() => new BookingManager(null));
        }

        [TestMethod]
        public void Constructor_ForEmptyRoomsList_ShouldThrowRoomsInvalidException()
        {
            Assert.ThrowsException<InvalidRoomsException>(() => new BookingManager(new List<int>()));
        }

        [DataRow(0)]
        [DataRow(999)]
        [DataTestMethod]
        public void IsRoomAvailable_ForNonExistingRoom_ShouldReturnFalse(int roomNumber)
        {
            Assert.ThrowsException<InvalidRoomNumberException>(() => bookingManager.IsRoomAvailable(roomNumber, DateTime.Now));
        }

        [DataRow(101, 10, true)]
        [DataRow(101, 0, false)]
        [DataTestMethod]
        public void IsRoomAvailable_ForGivenArguments_ShouldReturnExpectedResult(int roomNumber, int addDays, bool expectedResult)
        {
            bookingManager.AddBooking("Rahul", totalRooms[0], DateTime.Today);

            Assert.AreEqual(expectedResult, bookingManager.IsRoomAvailable(roomNumber, DateTime.Today.AddDays(addDays)));
        }

        [TestMethod]
        public void AddBooking_ForInvalidRoomNumber_ShouldThrowInvalidRoomNumberException()
        {
            Assert.ThrowsException<InvalidRoomNumberException>(() => bookingManager.AddBooking("Rahul", 999, DateTime.Today));
        }

        [TestMethod]
        public void AddBooking_ForAlreadyBookedRoom_ShouldThrowRoomAlreadyBookedException()
        {
            bookingManager.AddBooking("Rahul", totalRooms[0], DateTime.Today);

            Assert.ThrowsException<RoomAlreadyBookedException>(() => bookingManager.AddBooking("Rahul", totalRooms[0], DateTime.Today));
        }

        [DataRow(101, 5)]
        [DataRow(101, 15)]
        [DataRow(102, 5)]
        [DataRow(102, 15)]
        [DataTestMethod]
        public void AddBooking_ForValidArgs_ShouldBookTheRoom(int roomNumber, int addDays)
        {
            bookingManager.AddBooking("Rahul", roomNumber, DateTime.Now.AddDays(addDays));

            Assert.IsFalse(bookingManager.IsRoomAvailable(roomNumber, DateTime.Now.AddDays(addDays)));
        }

        [TestMethod]
        public void GetAvailableRooms_ForAGivenDate_ShouldReturnAllAvailableRooms()
        {
            bookingManager.AddBooking("Rahul", totalRooms[0], DateTime.Now);

            var availableRooms = bookingManager.GetAvailableRooms(DateTime.Now);

            Assert.AreEqual(totalRooms.Count - 1, availableRooms.ToList().Count());
            Assert.IsTrue(availableRooms.Any(a => a != totalRooms[0]));
            Assert.IsTrue(availableRooms.Any(a => a == totalRooms[1]));
            Assert.IsTrue(availableRooms.Any(a => a == totalRooms[2]));
            Assert.IsTrue(availableRooms.Any(a => a == totalRooms[3]));
        }

        [TestMethod]
        public void GetAvailableRooms_ForInvalidDateParam_ShouldThrowInvalidDateArgumentException()
        {
            Assert.ThrowsException<InvalidDateException>(() => bookingManager.GetAvailableRooms(DateTime.Now.AddDays(-1)));
        }
    }
}