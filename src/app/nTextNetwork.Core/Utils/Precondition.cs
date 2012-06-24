using System;

namespace nTextNetwork.Core.Utils
{
    public static class Precondition
    {
        public static void EnsureNotNullOrEmpty(string argName, 
            string argValue)
        {
            if (String.IsNullOrEmpty(argValue))
                throw new ArgumentNullException(argName,
                    "Precondition violated string is null or empty");
        }

        public static void EnsureNotNull<T>(string argName, T argValue) 
            where T : class
        {
            if (argValue == null)
                throw new ArgumentNullException(argName,
                    "Precondition violated argument is null or empty");
        }

        public static void EnsureGreaterThanZero(string argName, 
            long argValue)
        {
            if (argValue <= 0)
                throw new ArgumentException(
                    "Precondition violated value is not greater than zero",
                    argName);
        }

        public static void EnsureGreaterOrEqualToZero(string argName, 
            long argValue)
        {
            if (argValue < 0)
                throw new ArgumentException(
                    "Precondition violated value is not "+
                    "greater or equal to zero",
                    argName);
        }

        public static void EnsureIsTrue(string argName, bool condition)
        {
            if (!condition)
                throw new ArgumentException(
                    "Precondition violated: argument is false. Expected true",
                    argName);
        }
    }
}