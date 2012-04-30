using System;
using System.Collections.Generic;
using nText.Core.Util;

namespace nText.Core
{
    public class TextStatistics : ITextStatistics
    {
        public TextStatistics(string text)
        {
            Precondition.EnsureNotNullOrEmpty("text", text);
            Text = text;
        }

        public string Text { get; private set; }
        public IList<char> PunctuationLiterals { get; private set; }
        public int SymbolsCount { get; private set; }
        public int UniqueSymbolsCount { get; private set; }
        public IDictionary<string, int> WordFrequencyDictionary { get; private set; }
        public IDictionary<string, int> PunctuationFrequencyDictionary { get; private set; }

        public ITextStatistics Generate()
        {
            throw new NotImplementedException();
        }
    }
}