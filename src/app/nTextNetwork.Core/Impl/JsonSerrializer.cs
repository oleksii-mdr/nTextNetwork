using nTextNetwork.Core.Interfaces;
using ServiceStack.Text;
using nTextNetwork.Core.Utils;

namespace nTextNetwork.Core.Impl
{
    public class JsonSerrializer<T> : IJsonSerrializer<T> where T : class
    {
        public T Deserialize(string json)
        {
            Precondition.EnsureNotNull("json", json);
            return JsonSerializer.DeserializeFromString<T>(json);
        }

        public string Serialize(T obj)
        {
            Precondition.EnsureNotNull("obj", obj);
            return JsonSerializer.SerializeToString(obj);
        }
    }
}