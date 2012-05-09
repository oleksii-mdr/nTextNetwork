using System;
using System.Configuration;
using System.IO;
using nText.Core.Interface;
using nText.Core.Util;

namespace nText.Core.Impl
{
    internal class StreamConverter : IStreamConverter
    {
        public const int DEFAULT_MAX_STREAM_SIZE = 1000000;

        public string ToText(Stream stream)
        {
            Precondition.EnsureNotNull("stream", stream);
            Precondition.EnsureMoreThanZero("stream.Length", stream.Length);
            
            int max;
            try
            {
                string str = ConfigurationManager
                                      .AppSettings["maxAllowedInputBytes"];
                if (!Int32.TryParse(str, out max))
                {
                    max = DEFAULT_MAX_STREAM_SIZE;
                }
            }
            catch (ConfigurationErrorsException)
            {
                max = DEFAULT_MAX_STREAM_SIZE;
            }

            if (stream.Length > max)
            {
                throw new OutOfMemoryException(
                    "Cannot process request of this size. " +
                    "Object is to large: " + stream.Length +
                    " bytes. Max allowed: " + max);
            }

            TextReader r = new StreamReader(stream);
            return r.ReadToEnd();
        }
    }
}