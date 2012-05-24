using System;

namespace nText.Core.Utils
{
    internal static class Precondition
    {
        internal static void EnsureNotNullOrEmpty(string argName, string argValue) 
        {
            if (String.IsNullOrEmpty(argValue))
                throw new ArgumentNullException(argName,
                    "Precondition violated string is null or empty");
        }

        internal static void EnsureNotNull<T>(string argName, T argValue) where T : class
        {
            if (argValue == null)
                throw new ArgumentNullException(argName,
                    "Precondition violated argument is null or empty");
        }

        internal static void EnsureMoreThanZero(string argName, long argValue)
        {
            if (argValue <= 0)
                throw new ArgumentNullException(argName,
                    "Precondition violated value is not more that zero");
        }
    }
}