using System.Collections.Generic;

namespace nTextNetwork.Core.Interfaces
{
    public interface IBufferedTextReader
    {
        /// <summary>
        ///BufferedTextReader can read until end of stream reached
        /// </summary>
        bool CanRead { get; }

        /// <summary>
        /// Reads stream for <paramref name="minBufferSize"/> symbols then 
        /// reads each next char to get to the nearest separator char
        /// </summary>
        /// <param name="minBufferSize">read at least this number of chars, 
        /// if the last char is not a separator char, continue reading till 
        /// nearest separator char</param>
        /// <param name="chunk">output string that was read from stream</param>
        /// <param name="separators">separators are strated looked into when 
        /// the buffer is full. Once a occurs in a stream the method returns
        /// </param>
        /// <returns>number of chars read</returns>
        int Read(int minBufferSize, out string chunk, List<char> separators);
    }
}