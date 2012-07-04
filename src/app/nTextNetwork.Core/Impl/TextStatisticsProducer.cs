using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using nTextNetwork.Core.Text;
using nTextNetwork.Core.Utils;

namespace nTextNetwork.Core.Impl
{
    /// <summary>
    /// Produce shunks of text read from the input stream
    /// </summary>
    public class TextStatisticsProducer
    {
        public Stream WorkingStream { get; private set; }
        public ConcurrentBag<string> Location { get; private set; }
        public int MinBufferSize { get; private set; }
        public List<char> Separators { get; private set; }

        public TextStatisticsProducer(
            Stream stream, ConcurrentBag<string> location,
            int minBufferSize, List<char> separators)
        {
            WorkingStream = stream;
            Location = location;
            MinBufferSize = minBufferSize;
            Separators = separators;
        }

        private Task ProduceAsync(
            Stream stream,
            CancellationToken cancelToken,
            Action<int> OnProgressReported = null)
        {
            Precondition.EnsureNotNull("stream", stream);
            Precondition.EnsureIsTrue("stream.CanRead", stream.CanRead);
            Precondition.EnsureGreaterThanZero("stream.Length", stream.Length);

            return Task.Factory.StartNew(
                () =>
                {
                    int readCount = 1;
                    var reader = new BufferedTextReader(stream);

                    while (readCount > 0)
                    {
                        string chunk;
                        readCount = reader.Read(
                            MinBufferSize,
                            out chunk,
                            Separators);

                        Location.Add(chunk);
                        if (OnProgressReported != null)
                        {
                            OnProgressReported.BeginInvoke(readCount, null, null);
                        }

                        cancelToken.ThrowIfCancellationRequested();
                        break;
                    }
                },
                cancelToken,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }
    }
}