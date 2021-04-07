using System;

namespace WritingPlatformCore.Exceptions
{
    public class CabinetNotFoundException : Exception
    {
        public CabinetNotFoundException(int cabinetId):base($"No cabinet found with id {cabinetId}")
        {

        }

        protected CabinetNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context) { }
        public CabinetNotFoundException(string message) : base(message)
        {

        }
        public CabinetNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
