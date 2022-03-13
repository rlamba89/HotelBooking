using System;
using System.Runtime.Serialization;

namespace HotelBooking.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException()
        {
        }

        public InvalidDateException(string message) : base(message)
        {
        }

        public InvalidDateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
