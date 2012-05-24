using System.Collections.Generic;

namespace nText.Core.Interfaces
{
    public interface IDictionarySerrializer<T,K>
    {
        string Serrialize(IDictionary<T, K> dictionary);
    }
}