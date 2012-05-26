using System;

namespace nTextNetwork.Core.Exceptions
{
    public class ObjectIsTooLargeException : Exception
    {
        public ObjectIsTooLargeException()
        {
        }

        public ObjectIsTooLargeException(string message)
            : base(message)
        {
        }

        public ObjectIsTooLargeException(string message,
                                        Exception innerException)
            : base(message, innerException)
        {
        }
    }
}