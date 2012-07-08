using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using nTextNetwork.Core.Utils;
using Newtonsoft.Json;
using nTextNetwork.Presentation.Web.Models.LightWeight;

namespace nTextNetwork.Presentation.Web.Models.Utils
{
    /// <summary>
    /// Serialize data into json in the special format.
    /// </summary>
    public class JsonSerializerForJit
    {
        public string Serialize(IDictionary<string, int> dictionary)
        {
            Precondition.EnsureNotNull("dictionary", dictionary);

            TreeMapNode root = new TreeMapNode();
            
            int size = dictionary.Count;

            var colors = ColorHelper.GetGradientHexColors(
                //ColorTranslator.FromHtml("#EBEB35"), 
                    Color.Yellow,
                    Color.ForestGreen,
                    Color.Red, size)
                .ToList();

            for (int i = 0; i < size; i++)
            {
                var item = dictionary.ElementAt(i);

                TreeMapNode child = new TreeMapNode { Id = item.Key, Name = item.Key };
                TreeMapNodeItem data = new TreeMapNodeItem
                {
                    Area = item.Value,
                    Color = colors[i],
                    Count = item.Value.ToString(CultureInfo.InvariantCulture)
                };

                child.Data = data;
                root.Children.Add(child);
            }

            return JsonConvert.SerializeObject(root);
        }
    }
}
