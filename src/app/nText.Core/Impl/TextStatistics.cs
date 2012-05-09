using System;
using System.Collections.Generic;
using nText.Core.Interface;
using nText.Core.Util;

namespace nText.Core.Impl
{
    public class TextStatistics : ITextStatistics
    {
        public TextStatistics()
        {
            PunctuationLiterals = new List<char>();
            WordFrequencyDictionary = new Dictionary<string, int>();
            PunctuationFrequencyDictionary = new Dictionary<string, int>();
        }

        public TextStatistics(string text)
            : this()
        {
            Precondition.EnsureNotNullOrEmpty("text", text);
            Text = text;
        }

        internal static ITextStatistics DefaultInstance
        {
            get { return new TextStatistics(String.Empty); }
        }

        public string Text { get; private set; }
        public IList<char> PunctuationLiterals { get; private set; }
        public int SymbolsCount { get; private set; }
        public int UniqueSymbolsCount { get; private set; }
        public IDictionary<string, int> WordFrequencyDictionary { get; private set; }
        public IDictionary<string, int> PunctuationFrequencyDictionary { get; private set; }

        ITextStatistics ITextStatistics.Build()
        {
            Precondition.EnsureNotNullOrEmpty("Text", Text);

            return null;
        }

        
    }
}