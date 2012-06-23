using System.IO;
using System.Threading;
using System.Threading.Tasks;
using nTextNetwork.Core.Interfaces;
using nTextNetwork.Core.Utils;
using TextReader = nTextNetwork.Core.Text.TextReader;

namespace nTextNetwork.Core.Impl
{
    public class TextStatisticsBuilderAsync
    {
        public Task<ITextStatistic> BuildAsync(Stream stream)
        {
            return BuildAsync(stream, CancellationToken.None);
        }

        public Task<ITextStatistic> BuildAsync(Stream stream,
            CancellationToken cancellationToken)
        {
            Precondition.EnsureNotNull("stream", stream);
            Precondition.EnsureIsTrue("stream.CanRead", stream.CanRead);
            Precondition.EnsureGreaterThanZero("stream.Length", stream.Length);


            return BuildAsyncInternal(stream, cancellationToken);
        }

        private Task<ITextStatistic> BuildAsyncInternal(Stream stream,
            CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
                Crunch(stream, cancellationToken),
                cancellationToken);

        }

        internal ITextStatistic Crunch(Stream stream,
            CancellationToken cancellationToken)
        {
            int readCount = -1;
            int bufferSize = 1024;
            string chunk;

            var reader = new TextReader(stream);

            while (readCount > 0)
            {
                readCount = reader.ReadUntilSpace(
                    bufferSize, out chunk);
                
                cancellationToken.ThrowIfCancellationRequested();
                
                break;
            }
            return new TextStatistic() as ITextStatistic;
        }
    }
}