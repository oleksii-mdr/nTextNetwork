using System;
using System.Collections.Generic;
using System.Linq;
using nTextNetwork.Core.Interfaces;
using nTextNetwork.Core.Utils;

namespace nTextNetwork.Core.Impl
{
    public class TextStatistic : ITextStatistic
    {
        internal TextStatistic()
        {
            PunctuationLiterals = new List<char>();
            UniqueLiterals = new List<char>();
            LiteralsFrequencyDictionary = new Dictionary<char, int>();
            WordFrequencyDictionary = new Dictionary<string, int>();
            PunctuationFrequencyDictionary = new Dictionary<char, int>();
        }

        public TextStatistic(string text)
            : this()
        {
            Precondition.EnsureNotNullOrEmpty("text", text);
            Text = text;
        }

        internal static ITextStatistic DefaultInstance
        {
            get { return new TextStatistic(String.Empty); }
        }

        public string Text { get; private set; }
        public int TextLenght { get; private set; }

        public int UniqueLiteralsCount { get; private set; }
        public IEnumerable<char> UniqueLiterals { get; private set; }
        public IDictionary<char, int> LiteralsFrequencyDictionary { get; private set; }

        public int UniquePunctuationLiteralsCount { get; private set; }
        public IEnumerable<char> PunctuationLiterals { get; private set; }
        public IDictionary<char, int> PunctuationFrequencyDictionary { get; private set; }

        public int UniqueWordsCount { get; private set; }
        public IEnumerable<string> UniqueWords { get; private set; }
        public IDictionary<string, int> WordFrequencyDictionary { get; private set; }
        public IDictionary<string, double> WordProbabilityDictionary { get; private set; }

        public double ShannonEntropy { get; private set; }

        //TODO there is a lot of space for optimization
        ITextStatistic ITextStatistic.Build()
        {
            Precondition.EnsureNotNullOrEmpty("Text", Text);

            //symbols count
            TextLenght = Text.Length;

            //-----------------------------------------------------------------

            //unique literals 
            LiteralsFrequencyDictionary = (from character in Text
                                           where !char.IsPunctuation(character)
                                           where !char.IsWhiteSpace(character)
                                           group Text by character into g
                                           let count = g.Count()
                                           orderby count descending
                                           select new { g.Key, count })
                                           .AsParallel()
                                           .ToDictionary(
                                                arg => arg.Key,
                                                arg => arg.count);

            UniqueLiterals = LiteralsFrequencyDictionary.Keys;
            UniqueLiteralsCount = UniqueLiterals.Count();

            //-----------------------------------------------------------------

            //punctuation
            PunctuationFrequencyDictionary = (from character in Text
                                            where char.IsPunctuation(character)
                                            group Text by character into g
                                            let count = g.Count()
                                            orderby count descending
                                            select new { g.Key, count })
                                            .AsParallel()
                                            .ToDictionary(
                                                arg => arg.Key,
                                                arg => arg.count);



            PunctuationLiterals = PunctuationFrequencyDictionary.Keys;
            UniquePunctuationLiteralsCount = PunctuationLiterals.Count();

            //-----------------------------------------------------------------

            //words
            //add space to punctuation chars
            var separators = new List<char>(PunctuationLiterals) { ' ' };
            //strip string of punctuation and white space
            var allWords = Text.Split(
                                separators.ToArray(),
                                StringSplitOptions.RemoveEmptyEntries);

            WordFrequencyDictionary = (from word in allWords
                                       group allWords by word into g
                                       let count = g.Count()
                                       orderby count descending
                                       select new { g.Key, count })
                                      .AsParallel()
                                      .ToDictionary(
                                            arg => arg.Key,
                                            arg => arg.count);

            UniqueWords = WordFrequencyDictionary.Keys;
            UniqueWordsCount = UniqueWords.Count();

            int allWordsCount = WordFrequencyDictionary
                                .Sum(pair => pair.Value);

            WordProbabilityDictionary = (from word in WordFrequencyDictionary
                                        select word)
                                        .ToDictionary(
                                            arg => arg.Key,
                                            arg => (double)arg.Value / allWordsCount);

            ShannonEntropy = -WordProbabilityDictionary
                                  .Sum(pair =>
                                       pair.Value*Math.Log(pair.Value, 2));
                            

            return this;
        }
    }
}