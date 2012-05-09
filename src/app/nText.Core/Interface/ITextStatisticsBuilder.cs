using System.IO;
using nText.Core.Impl;

namespace nText.Core.Interface
{
    public interface ITextStatisticsBuilder
    {
        ITextStatistics Build(Stream stream);
    }
}