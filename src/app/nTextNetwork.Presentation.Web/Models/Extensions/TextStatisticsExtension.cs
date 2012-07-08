using nTextNetwork.Core.Interfaces;
using nTextNetwork.Presentation.Web.Models.LightWeight;

namespace nTextNetwork.Presentation.Web.Models.Extensions
{
    public static class TextStatisticsExtension
    {
        public static LightWeightObject ToLightWeight(this ITextStatistic iStatistic)
        {
            LightWeightObject lightWeightObject = new LightWeightObject
                {
                    WordFrequencyDictionary = iStatistic.WordFrequencyDictionary
                };

            return lightWeightObject;
        }
    }
}