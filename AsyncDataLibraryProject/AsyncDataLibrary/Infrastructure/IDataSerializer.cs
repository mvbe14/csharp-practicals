namespace AsyncDataLibrary.Infrastructure;

public interface IDataSerializer
{
    string Serialize<T>(IEnumerable<T> items);
    List<T> Deserialize<T>(string json);
}
