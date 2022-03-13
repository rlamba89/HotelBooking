using System;
using System.Runtime.Serialization;

namespace HotelBooking.Exceptions
{
    public class InvalidRoomNumberException : Exception
    {
        public InvalidRoomNumberException()
        {
        }

        public InvalidRoomNumberException(string message) : base(message)
        {
        }

        public InvalidRoomNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRoomNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
