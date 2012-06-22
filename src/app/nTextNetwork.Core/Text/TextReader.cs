using System;
using System.IO;
using System.Text;

namespace nTextNetwork.Core.Text
{
    public class TextReader : IDisposable
    {
        StreamReader reader;

        public TextReader(Stream stream)
        {
            reader = new StreamReader(stream);
        }

        /// <summary>
        /// Reads stream for <paramref name="minCount"/> symbols
        /// then reads each next char to get to the nearest SPACE char
        /// </summary>
        /// <param name="stream">input stream</param>
        /// <param name="startIndex">start reading position</param>
        /// <param name="minCount">read at least this number of chars, 
        /// if the last char is not SPACE, 
        /// continue reading till nearest SPACE</param>
        /// <param name="chunk">output string that was read from stream</param>
        /// <returns>number of chars read</returns>
        public int ReadUntilSpace(int startIndex,
            int minCount, out string chunk)
        {
            //init main buffer
            char[] buffer = new char[minCount];
            //init buffer used for single char read
            char[] singleBuffer = new char[1];
            //init chunk with empty string
            chunk = String.Empty;

            int readCount;
            StringBuilder sb;
            
            

            readCount = reader.ReadBlock(buffer, startIndex, minCount);

            //last symbol is SPACE
            if (buffer[minCount - 1] == ' ')
            {
                //we luck, define string and return number of chars read
                chunk = new string(buffer);
                return readCount;
            }

            //not SPACE, reading one char at a time
            string bufferString = new string(buffer);
            sb = new StringBuilder(bufferString);

            while (true)
            {
                //peek into next symbol
                int nextChar = reader.Peek();
                //EOS break the loop
                if (nextChar == -1)
                    break;

                //read char
                sb.Append(reader.ReadBlock(singleBuffer, startIndex, 1));
                readCount++;

                //if it is SPACE break the loop
                if ((char)nextChar == ' ')
                    break;
            }

            //get the chunk
            chunk = sb.ToString();

            //return number of bytes read
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