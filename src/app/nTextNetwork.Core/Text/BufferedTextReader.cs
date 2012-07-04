using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using nTextNetwork.Core.Interfaces;
using nTextNetwork.Core.Utils;

namespace nTextNetwork.Core.Text
{
    public class BufferedTextReader : IDisposable, IBufferedTextReader
    {
        private readonly StreamReader _reader;

        public BufferedTextReader(Stream stream)
        {
            Precondition.EnsureNotNull("stream", stream);

            _reader = new StreamReader(stream);

            Postcondition.EnsureNotNull("reader", _reader);
        }

        /// <summary>
        ///BufferedTextReader can read until end of stream reached
        /// </summary>
        public bool CanRead
        {
            get { return _reader.Peek() != -1; }
        }

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
        public int Read(int minBufferSize, out string chunk,
            List<char> separators)
        {
            Precondition.EnsureGreaterThanZero("minBufferSize", minBufferSize);

            //init main buffer
            var buffer = new char[minBufferSize];
            //init buffer used for single char read
            var singleBuffer = new char[1];
            //init chunk with empty string

            int readCount = _reader.ReadBlock(buffer, 0, minBufferSize);

            //last symbol
            char lastChar = buffer[minBufferSize - 1];
            
            //last one is a separator
            if (separators.Contains(lastChar))
            {
                //we are lucky, define string and return number of chars read
                chunk = new string(buffer);
                chunk = chunk.TrimEnd('\0');
                Postcondition.EnsureNotNullOrEmpty("chunk", chunk);
                return readCount;
            }

            //not separator, reading one char at a time
            string bufferString = new string(buffer);
            var sb = new StringBuilder(bufferString);

            while (true)
            {
                //peek into next symbol
                int nextChar = _reader.Peek();
                //EOS break the loop
                if (nextChar == -1)
                    break;

                //read char
                _reader.ReadBlock(singleBuffer, 0, 1);
                sb.Append(singleBuffer);
                readCount++;

                //if it is a separator break the loop
                if (separators.Contains((char)nextChar))
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
                if (_reader != null)
                {
                    _reader.Dispose();
                }
            }
        }
    }
}