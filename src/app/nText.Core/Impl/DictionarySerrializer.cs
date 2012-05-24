using System.Collections.Generic;
using System.Text;
using nText.Core.Interfaces;
using nText.Core.Utils;

namespace nText.Core.Impl
{
    public class DictionarySerrializer<T, K> : IDictionarySerrializer<T, K>
    {
        public string Serrialize(IDictionary<T, K> dictionary)
        {
            Precondition.EnsureNotNull("dictionary", dictionary);
            
            var stringBuilder = new StringBuilder();
            
            stringBuilder.Append("{");
            foreach (var value in dictionary)
            {
                stringBuilder.AppendFormat("\"{0}\":{1},", value.Key, value.Value);
            }
            stringBuilder.Append("}");
            stringBuilder.Replace(",}", "}");
            
            return stringBuilder.ToString();
        }
    }
}