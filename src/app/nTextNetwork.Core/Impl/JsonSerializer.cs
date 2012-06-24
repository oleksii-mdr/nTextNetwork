using nTextNetwork.Core.Interfaces;
using nTextNetwork.Core.Utils;
using JsonSerializer = ServiceStack.Text.JsonSerializer;

namespace nTextNetwork.Core.Impl
{
    public class JsonSerializer<T> : IJsonSerializer<T> where T : class
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