using System;
using System.IO;

namespace nTextNetwork.Core.Test.Utils
{
    public static class TestPrecondition
    {
        public static void EnsureCanParse(string str, out int result)
        {
            if (!Int32.TryParse(str, out result))
            {
                throw new FormatException("Precondition violated. " +
                    "Cannot parse the string into an int: '" + str + "'");
            }
        }

        public static void EnsureFileExist(string fName)
        {
            if (!File.Exists(fName))
            {
                throw new IOException("Precondition violated. " +
                    "Cannot find path: '" + fName + "'");
            }
        }
    }
}