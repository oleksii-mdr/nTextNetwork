using System.Collections.Generic;

namespace nText.Core.Interfaces
{
    /// <summary>
    /// Defines static statistics that can be collected from text
    /// </summary>
    public interface ITextStatistic
    {
        /// <summary>
        /// Contains a string for which metrics will be calculated
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Defines the length of the text, this include all literals:
        /// white spaces, punctuations, printable and non-printable
        /// characters, caret returns and new line and others
        /// </summary>
        int TextLenght { get; }


        /// <summary>
        /// Defines the number of unique literals 
        /// Excluding: white space and punctuation 
        /// Including: printable and non-printable characters,
        /// caret returns and new line and all other literals
        /// </summary>
        int UniqueLiteralsCount { get; }

        /// <summary>
        /// Defines a enumeration of unique literals 
        /// Excluding: white space and punctuation 
        /// Including: printable and non-printable characters,
        /// caret returns and new line and all other literals
        /// </summary>
        IEnumerable<char> UniqueLiterals { get; }

        /// <summary>
        /// Defines a dictionary of unique literals with 
        /// frequency of occurance
        /// Excluding: white space and punctuation 
        /// Including: printable and non-printable characters,
        /// caret returns and new line and all other literals
        /// </summary>
        IDictionary<char, int> LiteralsFrequencyDictionary { get; }

        /// <summary>
        /// Defines the number of unique punctuation literals 
        /// Excluding: white space 
        /// Including: punctuation literals
        /// </summary>
        int UniquePunctuationLiteralsCount { get; }

        /// <summary>
        /// Defines a enumeration of unique punctuation literals 
        /// Excluding: white space 
        /// Including: punctuation literals
        /// </summary>
        IEnumerable<char> PunctuationLiterals { get; }

        /// <summary>
        /// Defines a dictionary of unique punctuation literals with 
        /// frequency of occurance
        /// Excluding: white space 
        /// Including: punctuation literals
        /// </summary>
        IDictionary<char, int> PunctuationFrequencyDictionary { get; }

        /// <summary>
        /// Defines the number of unique words 
        /// separated by whitespace or punctuation literals 
        /// Excluding: white space, punctuation literals 
        /// Including: words, new lines and carret returns
        /// </summary>
        int UniqueWordsCount { get; }

        /// <summary>
        /// Defines a enumeration of unique words 
        /// separated by whitespace or punctuation literals 
        /// Excluding: white space, punctuation literals 
        /// Including: words, new lines and carret returns
        /// </summary>
        IEnumerable<string> UniqueWords { get; }

        /// <summary>
        /// Defines a dictionary of unique words with 
        /// frequency of occurance
        /// separated by whitespace or punctuation literals 
        /// Excluding: white space, punctuation literals 
        /// Including: words, new lines and carret returns
        /// </summary>
        IDictionary<string, int> WordFrequencyDictionary { get; }

        /// <summary>
        /// Implements builder pattern, analyses text for statistics
        /// </summary>
        /// <returns>Current instance of ITextStatistic, which was build based
        /// on the Text input
        /// </returns>
        ITextStatistic Build();
    }
}