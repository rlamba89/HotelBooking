using System;
using System.Runtime.Serialization;

namespace HotelBooking.Exceptions
{
    public class RoomAlreadyBookedException : Exception
    {
        public RoomAlreadyBookedException()
        {
        }

        public RoomAlreadyBookedException(string message) : base(message)
        {
        }

        public RoomAlreadyBookedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoomAlreadyBookedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
