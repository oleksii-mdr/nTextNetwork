using System;
using System.IO;
using System.Text;
using nTextNetwork.Core.Utils;

namespace nTextNetwork.Core.Text
{
    public class TextReader : IDisposable
    {
        private StreamReader reader;

        public TextReader(Stream stream)
        {
            Precondition.EnsureNotNull("stream", stream);

            reader = new StreamReader(stream);

            Postcondition.EnsureNotNull("reader", reader);
        }

        /// <summary>
        ///TextReader can read until end of stream reached
        /// </summary>
        public bool CanRead
        {
            get { return reader.Peek() != -1; }
        }

        /// <summary>
        /// Reads stream for <paramref name="minBufferSize"/> symbols
        /// then reads each next char to get to the nearest SPACE char
        /// </summary>
        /// <param name="minBufferSize">read at least this number of chars, 
        /// if the last char is not SPACE, 
        /// continue reading till nearest SPACE</param>
        /// <param name="chunk">output string that was read from stream</param>
        /// <returns>number of chars read</returns>
        public int ReadUntilSpace(int minBufferSize, out string chunk)
        {
            Precondition.EnsureGreaterThanZero("minBufferSize", minBufferSize);

            //init main buffer
            char[] buffer = new char[minBufferSize];
            //init buffer used for single char read
            char[] singleBuffer = new char[1];
            //init chunk with empty string
            chunk = String.Empty;

            int readCount = reader.ReadBlock(buffer, 0, minBufferSize);

            //last symbol is SPACE
            if (buffer[minBufferSize - 1] == ' ')
            {
                //we luck, define string and return number of chars read
                
                chunk = new string(buffer);
                chunk = chunk.TrimEnd('\0');
                Postcondition.EnsureNotNullOrEmpty("chunk", chunk);
                return readCount;
            }

            //not SPACE, reading one char at a time
            string bufferString = new string(buffer);
            var sb = new StringBuilder(bufferString);

            while (true)
            {
                //peek into next symbol
                int nextChar = reader.Peek();
                //EOS break the loop
                if (nextChar == -1)
                    break;

                //read char
                reader.ReadBlock(singleBuffer, 0, 1);
                sb.Append(singleBuffer);
                readCount++;

                //if it is SPACE break the loop
                if ((char)nextChar == ' ')
                    break;
            }

            //get the chunk
            chunk = sb.ToString();
            chunk = chunk.TrimEnd('\0');

            //return number of bytes read
            Postcondition.EnsureNotNullOrEmpty("chunk", chunk);
            return readCount;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
            }
        }
    }
}