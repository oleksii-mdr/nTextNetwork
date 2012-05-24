using System.Collections.Generic;
using nText.Core.Interfaces;
using nText.Core.Utils;

namespace nText.Core.Impl
{
    public class DictionarySerrializer<T, K> : IDictionarySerrializer<T, K>
    {
        public string Serrialize(IDictionary<T, K> dictionary)
        {
            Precondition.EnsureNotNull("dictionary", dictionary);

            return "";
        }
    }
}