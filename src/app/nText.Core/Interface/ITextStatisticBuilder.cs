using System.IO;
using nText.Core.Impl;

namespace nText.Core.Interface
{
    public interface ITextStatisticBuilder
    {
        ITextStatistic Build(Stream stream);
    }
}