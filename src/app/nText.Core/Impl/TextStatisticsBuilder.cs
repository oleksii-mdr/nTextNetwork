using System.IO;
using nText.Core.Interface;
using nText.Core.Util;

namespace nText.Core.Impl
{
    public class TextStatisticsBuilder : ITextStatisticsBuilder
    {
        public ITextStatistics Build(Stream stream)
        {
            Precondition.EnsureNotNull("stream", stream);

            IStreamConverter converter = new StreamConverter();
            string txt = converter.ToText(stream);

            ITextStatistics stats = new TextStatistics(txt);
            return stats.Build();
        }
    }
}