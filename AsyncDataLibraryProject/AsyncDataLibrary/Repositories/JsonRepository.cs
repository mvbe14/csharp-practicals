using AsyncDataLibrary.Attributes;
using AsyncDataLibrary.Infrastructure;
using AsyncDataLibrary.Interfaces;

namespace AsyncDataLibrary.Repositories;

public sealed class JsonRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly IDataSerializer _serializer;
    private readonly string _filePath;

    public JsonRepository(FileStorageProvider storageProvider, IDataSerializer serializer)
    {
        _serializer = serializer;
        _filePath = storageProvider.GetPath(GetFileName());
        EnsureFileCreated();
    }

    public List<T> GetAll()
    {
        var json = File.ReadAllText(_filePath);
        return _serializer.Deserialize<T>(json);
    }

    public async Task<List<T>> GetAllAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);
        return _serializer.Deserialize<T>(json);
    }

    public T? GetById(int id)
    {
        return GetAll().FirstOrDefault(item => item.Id == id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var items = await GetAllAsync();
        return items.FirstOrDefault(item => item.Id == id);
    }

    public T Add(T item)
    {
        var items = GetAll();
        item.Id = GetNextId(items);
        items.Add(item);
        Save(items);
        return item;
    }

    public async Task<T> AddAsync(T item)
    {
        var items = await GetAllAsync();
        item.Id = GetNextId(items);
        items.Add(item);
        await SaveAsync(items);
        return item;
    }

    public bool Update(T item)
    {
        var items = GetAll();
        var index = items.FindIndex(current => current.Id == item.Id);
        if (index < 0)
            return false;

        items[index] = item;
        Save(items);
        return true;
    }

    public async Task<bool> UpdateAsync(T item)
    {
        var items = await GetAllAsync();
        var index = items.FindIndex(current => current.Id == item.Id);
        if (index < 0)
            return false;

        items[index] = item;
        await SaveAsync(items);
        return true;
    }

    public bool Delete(int id)
    {
        var items = GetAll();
        var item = items.FirstOrDefault(current => current.Id == id);
        if (item is null)
            return false;

        items.Remove(item);
        Save(items);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var items = await GetAllAsync();
        var item = items.FirstOrDefault(current => current.Id == id);
        if (item is null)
            return false;

        items.Remove(item);
        await SaveAsync(items);
        return true;
    }

    private void Save(List<T> items)
    {
        var json = _serializer.Serialize(items);
        File.WriteAllText(_filePath, json);
    }

    private async Task SaveAsync(List<T> items)
    {
        var json = _serializer.Serialize(items);
        await File.WriteAllTextAsync(_filePath, json);
    }

    private static int GetNextId(List<T> items)
    {
        return items.Count == 0 ? 1 : items.Max(item => item.Id) + 1;
    }

    private static string GetFileName()
    {
        var attribute = typeof(T)
            .GetCustomAttributes(typeof(StorageFileAttribute), false)
            .FirstOrDefault() as StorageFileAttribute;

        if (attribute is null)
            throw new InvalidOperationException($"Model {typeof(T).Name} must have StorageFileAttribute.");

        return attribute.FileName;
    }

    private void EnsureFileCreated()
    {
        if (!File.Exists(_filePath))
            File.WriteAllText(_filePath, "[]");
    }
}
