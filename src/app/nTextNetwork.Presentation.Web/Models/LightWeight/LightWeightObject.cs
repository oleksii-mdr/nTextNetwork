using System.Collections.Generic;
using MongoDB.Bson;

namespace nTextNetwork.Presentation.Web.Models.LightWeight
{
    /// <summary>
    /// We store small object in the database instead of full ITextStatistics.
    /// </summary>
    public class LightWeightObject
    {
        //public IDictionary<string, double> WordProbabilityDictionary { get; set; }
        public IDictionary<string, int> WordFrequencyDictionary  { get; set; }
        //public IEnumerable<char> PunctuationLiterals  { get; set; }
        public string Text  { get; set; }
        public ObjectId Id  { get; set; } 
    }
}