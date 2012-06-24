using System.Drawing;

namespace nTextNetwork.Presentation.Web.Models
{
   public class ColorHelper
    {
       private static int _red;
       private static int _green;
       private static int _blue;

        public static string GetHexColor(int matches, int countForSerialization)
        {
            _green = 255 - matches * 10;

             if (_green <= 0)
             {
                 _green = 0;
                 _blue += 10;
             }

             if (_blue >= 255)
             {
                 _blue = 0;
                 _red += 10;
             }

            return ColorTranslator.ToHtml(
               
                Color.FromArgb(
                     0,
                    _red, 
                    _green, 
                    _blue
                    ));
        }
    }
}
