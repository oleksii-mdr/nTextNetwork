//using System.IO;
//using System.Threading;
//using System.Threading.Tasks;
//using nTextNetwork.Core.Interfaces;
//using nTextNetwork.Core.Text;
//using nTextNetwork.Core.Utils;

//namespace nTextNetwork.Core.Impl
//{
//    public class TextStatisticsBuilderAsync
//    {
//        public Task<ITextStatistic> BuildAsync(WorkingStream stream)
//        {
//            return BuildAsync(stream, CancellationToken.None);
//        }

//        public Task<ITextStatistic> BuildAsync(WorkingStream stream,
//            CancellationToken cancellationToken)
//        {
//            Precondition.EnsureNotNull("stream", stream);
//            Precondition.EnsureIsTrue("stream.CanRead", stream.CanRead);
//            Precondition.EnsureGreaterThanZero("stream.Length", stream.Length);


//            return BuildAsyncInternal(stream, cancellationToken);
//        }

//        private Task<ITextStatistic> BuildAsyncInternal(WorkingStream stream,
//            CancellationToken cancellationToken)
//        {
//            return Task.Factory.StartNew(() =>
//                Crunch(stream, cancellationToken),
//                cancellationToken);

//        }

//        internal ITextStatistic Crunch(WorkingStream stream,
//            CancellationToken cancellationToken)
//        {
//            int readCount = -1;
//            int bufferSize = 1024;
//            string chunk;

//            var reader = new BufferedTextReader(stream);

//            while (readCount > 0)
//            {
//                readCount = reader.Read(
//                    bufferSize, out chunk);

//                cancellationToken.ThrowIfCancellationRequested();

//                break;
//            }
//            return new TextStatistic() as ITextStatistic;
//        }
//    }
//}