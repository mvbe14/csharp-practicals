namespace AsyncDataLibrary.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    List<T> GetAll();
    Task<List<T>> GetAllAsync();

    T? GetById(int id);
    Task<T?> GetByIdAsync(int id);

    T Add(T item);
    Task<T> AddAsync(T item);

    bool Update(T item);
    Task<bool> UpdateAsync(T item);

    bool Delete(int id);
    Task<bool> DeleteAsync(int id);
}
