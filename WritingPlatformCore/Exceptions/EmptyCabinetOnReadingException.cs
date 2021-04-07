using System;


namespace WritingPlatformCore.Exceptions
{
    public class EmptyCabinetOnReadingException : Exception
    {
        public EmptyCabinetOnReadingException()
           : base($"Cabinet cannot have 0 items to reading")
        {
        }

        protected EmptyCabinetOnReadingException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public EmptyCabinetOnReadingException(string message) : base(message)
        {
        }

        public EmptyCabinetOnReadingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
