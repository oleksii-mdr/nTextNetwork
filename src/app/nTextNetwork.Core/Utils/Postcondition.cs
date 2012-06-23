using System;

namespace nTextNetwork.Core.Utils
{
    public class Postcondition
    {
        internal static void EnsureNotNull<T>(string argName, T argValue)
            where T : class
        {
            if (argValue == null)
                throw new ArgumentNullException(argName,
                    "Precondition violated argument is null or empty");
        }

        internal static void EnsureNotNullOrEmpty(string returnValue,
            string argValue)
        {
            if (String.IsNullOrEmpty(argValue))
                throw new ArgumentNullException(returnValue,
                    "Postcondiotion violated. Result is null or empty");
        }
    }
}