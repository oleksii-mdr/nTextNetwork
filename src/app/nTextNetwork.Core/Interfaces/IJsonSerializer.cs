namespace nTextNetwork.Core.Interfaces
{
    public interface IJsonSerializer<T>
    {
        T Deserialize(string json);
        string Serialize(T obj);
    }
}