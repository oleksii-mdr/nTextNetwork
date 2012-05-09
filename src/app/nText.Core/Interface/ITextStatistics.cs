using System.Collections.Generic;

namespace nText.Core.Interface
{
    public interface ITextStatistics
    {
        string Text { get; }
        int SymbolsCount { get; }
        int UniqueSymbolsCount { get; }
        
        IList<char> PunctuationLiterals { get; }
        IDictionary<string, int> WordFrequencyDictionary { get; }
        IDictionary<string, int> PunctuationFrequencyDictionary { get; }

        ITextStatistics Build();
    }
}