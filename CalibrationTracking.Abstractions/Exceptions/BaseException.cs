using System.Runtime.Serialization;

namespace CalibrationTracking.Abstractions.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException()
        {
        }

        protected BaseException(string? message) : base(message)
        {
        }

        protected BaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected List<string> Errors { get; set; } = new List<string>();
    }
}
