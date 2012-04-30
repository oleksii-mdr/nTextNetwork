using System;

namespace nText.Core.Util
{
    internal static class Precondition
    {
        internal static void EnsureNotNullOrEmpty(string argName, string argValue) 
        {
            if (String.IsNullOrEmpty(argValue))
                throw new ArgumentNullException(argName,
                    "Precondition violated string is null or empty");
        }
    }
}