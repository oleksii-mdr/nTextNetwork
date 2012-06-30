using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using nTextNetwork.Core.Utils;
using Newtonsoft.Json;

namespace nTextNetwork.Presentation.Web.Models
{
    public class JsonSerializerForJit
    {
        public string Serialize(IDictionary<string, int> dictionary, int count)
        {
            Precondition.EnsureNotNull("dictionary", dictionary);

            Node root = new Node();
            int size = dictionary.Count;

            var colors = ColorHelper.GetGradientHexColors(
                    //ColorTranslator.FromHtml("#EBEB35"), 
                    Color.Yellow,
                    Color.ForestGreen, 
                    Color.Red, size)
                .ToList();

            for (int i = 0; i < size; i++ )
            {
                var item = dictionary.ElementAt(i);

                Node child = new Node { Id = item.Key, Name = item.Key };
                Data data = new Data
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
