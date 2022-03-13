using System;
using System.Runtime.Serialization;

namespace HotelBooking.Exceptions
{
    public class InvalidGuestNameException : Exception
    {
        public InvalidGuestNameException()
        {
        }

        public InvalidGuestNameException(string message) : base(message)
        {
        }

        public InvalidGuestNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGuestNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
