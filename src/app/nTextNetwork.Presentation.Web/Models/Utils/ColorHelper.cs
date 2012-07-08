using System;
using System.Collections.Generic;
using System.Drawing;

namespace nTextNetwork.Presentation.Web.Models.Utils
{
    /// <summary>
    /// Makes colors for boxes of TreeMap control.
    /// </summary>
    public class ColorHelper
    {
        public static IEnumerable<string> GetGradientHexColors
            (Color first, Color middle, Color last, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                Color c = GetGradientForThreeColors(first, middle, last, 
                    (double)i / steps);
                yield return ColorTranslator.ToHtml(c);
            }
        }

        private static Color GetGradientForThreeColors(Color first,
            Color middle, Color last, double position)
        {
            if (position < 0 || position > 1)
                throw new ArgumentException(
                    "Position should be between 0 and 1");

            double mix = (Math.Cos((position * 2 - 1) * Math.PI) + 1) / 2;
            Color tmp = position < 0.5 ? first : last;
            return GetGradientForTwoColors(mix, tmp, middle);
        }

        private static Color GetGradientForTwoColors(double position,
            Color start, Color end)
        {
            if (position < 0 || position > 1)
                throw new ArgumentException(
                    "Position should be between 0 and 1");

            double negativePosition = 1.0 - position;

            double alpha = Math.Min(start.A, end.A) + Math.Abs(start.A - end.A) *
                           (start.A > end.A ? negativePosition : position);
            double red = Math.Min(start.R, end.R) + Math.Abs(start.R - end.R) *
                         (start.R > end.R ? negativePosition : position);
            double green = Math.Min(start.G, end.G) + Math.Abs(start.G - end.G) *
                           (start.G > end.G ? negativePosition : position);
            double blue = Math.Min(start.B, end.B) + Math.Abs(start.B - end.B) *
                          (start.B > end.B ? negativePosition : position);

            return Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue);
        }
    }
}
