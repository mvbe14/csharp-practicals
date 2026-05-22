using System.Text.Json;

namespace AsyncDataLibrary.Infrastructure;

public sealed class JsonDataSerializer : IDataSerializer
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public string Serialize<T>(IEnumerable<T> items)
    {
        return JsonSerializer.Serialize(items, _options);
    }

    public List<T> Deserialize<T>(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return new List<T>();

        return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
    }
}
