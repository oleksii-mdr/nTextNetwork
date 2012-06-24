using System;

namespace nTextNetwork.Core.Utils
{
    public class Postcondition
    {
        public static void EnsureNotNull<T>(string argName, T argValue)
            where T : class
        {
            if (argValue == null)
                throw new ArgumentNullException(argName,
                    "Precondition violated argument is null or empty");
        }

        public static void EnsureNotNullOrEmpty(string returnValue,
            string argValue)
        {
            if (String.IsNullOrEmpty(argValue))
                throw new ArgumentNullException(returnValue,
                    "Postcondiotion violated. Result is null or empty");
        }
    }
}