namespace nTextNetwork.Core.Interfaces
{
    public interface IJsonSerrializer<T>
    {
        T Deserialize(string json);
        string Serialize(T obj);
    }
}