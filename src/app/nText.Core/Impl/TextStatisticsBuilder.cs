﻿using System.IO;
using nText.Core.Interface;
using nText.Core.Util;

namespace nText.Core.Impl
{
    public class TextStatisticsBuilder : ITextStatisticBuilder
    {
        public ITextStatistic Build(Stream stream)
        {
            Precondition.EnsureNotNull("stream", stream);

            IStreamConverter converter = new StreamConverter();
            string txt = converter.ToText(stream);

            ITextStatistic stats = new TextStatistic(txt);
            return stats.Build();
        }
    }
}