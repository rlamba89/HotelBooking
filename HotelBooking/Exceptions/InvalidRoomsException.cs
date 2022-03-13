using System;
using System.Runtime.Serialization;

namespace HotelBooking.Exceptions
{
    public class InvalidRoomsException : Exception
    {
        public InvalidRoomsException()
        {
        }

        public InvalidRoomsException(string message) : base(message)
        {
        }

        public InvalidRoomsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRoomsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
