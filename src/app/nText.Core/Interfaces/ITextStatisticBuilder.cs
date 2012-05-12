using System.IO;

namespace nText.Core.Interfaces
{
    /// <summary>
    /// Main wrapper for the text statistics builder 
    /// </summary>
    public interface ITextStatisticBuilder
    {
        ITextStatistic Build(Stream stream);
    }
}