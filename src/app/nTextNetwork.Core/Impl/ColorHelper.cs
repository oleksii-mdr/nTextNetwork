using System;
using System.Drawing;

namespace nTextNetwork.Core.Impl
{
   public class ColorHelper
    {
        static Random random = new Random();

        public static string GetHexColor()
        {           
            return ColorTranslator.ToHtml(
                Color.FromArgb(
                    random.Next(0, 255), 
                    random.Next(0, 255), 
                    random.Next(0, 255), 
                    0));
        }
    }
}
