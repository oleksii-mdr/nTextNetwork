using System;

namespace nTextNetwork.Core.Utils
{
    internal static class Precondition
    {
        internal static void EnsureNotNullOrEmpty(string argName, 
            string argValue)
        {
            if (String.IsNullOrEmpty(argValue))
                throw new ArgumentNullException(argName,
                    "Precondition violated string is null or empty");
        }

        internal static void EnsureNotNull<T>(string argName, T argValue) 
            where T : class
        {
            if (argValue == null)
                throw new ArgumentNullException(argName,
                    "Precondition violated argument is null or empty");
        }

        internal static void EnsureGreaterThanZero(string argName, 
            long argValue)
        {
            if (argValue <= 0)
                throw new ArgumentException(
                    "Precondition violated value is not greater than zero",
                    argName);
        }

        internal static void EnsureGreaterOrEqualToZero(string argName, 
            long argValue)
        {
            if (argValue < 0)
                throw new ArgumentException(
                    "Precondition violated value is not "+
                    "greater or equal to zero",
                    argName);
        }

        internal static void EnsureIsTrue(string argName, bool condition)
        {
            if (!condition)
                throw new ArgumentException(
                    "Precondition violated: argument is false. Expected true",
                    argName);
        }
    }
}