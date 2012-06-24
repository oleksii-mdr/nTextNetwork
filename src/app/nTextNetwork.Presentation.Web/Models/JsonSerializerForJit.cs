using System.Collections.Generic;
using System.Globalization;
using nTextNetwork.Core.Utils;
using Newtonsoft.Json;

namespace nTextNetwork.Presentation.Web.Models
{
    public class JsonSerializerForJit
    {
        public string Serialize(IDictionary<string, int> dictionary)
        {
            Precondition.EnsureNotNull("dictionary", dictionary);

            Node root = new Node();

            foreach (var item in dictionary)
            {
                Node child = new Node { Id = item.Key, Name = item.Key };
                Data data = new Data
                {
                    Area = item.Value,
                    Color = ColorHelper.GetHexColor(),
                    Count = item.Value.ToString(CultureInfo.InvariantCulture)
                };

                child.Data = data;

                root.Children.Add(child);
            }

            return JsonConvert.SerializeObject(root);
        }
    }
}
