using System.Collections.Generic;

namespace nTextNetwork.Core.Interfaces
{
    public interface IDictionarySerrializer<T,K>
    {
        string Serrialize(IDictionary<T, K> dictionary);
    }
}