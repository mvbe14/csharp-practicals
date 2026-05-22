using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public sealed class UserService
{
    private readonly IRepository<User> _users;

    public UserService(IRepository<User> users)
    {
        _users = users;
    }

    public List<User> GetAll() => _users.GetAll();
    public Task<List<User>> GetAllAsync() => _users.GetAllAsync();

    public User? GetById(int id) => _users.GetById(id);
    public Task<User?> GetByIdAsync(int id) => _users.GetByIdAsync(id);

    public User Add(User user)
    {
        Validate(user);
        return _users.Add(user);
    }

    public async Task<User> AddAsync(User user)
    {
        Validate(user);
        return await _users.AddAsync(user);
    }

    public bool Update(User user)
    {
        Validate(user);
        return _users.Update(user);
    }

    public Task<bool> UpdateAsync(User user)
    {
        Validate(user);
        return _users.UpdateAsync(user);
    }

    public bool Delete(int id) => _users.Delete(id);
    public Task<bool> DeleteAsync(int id) => _users.DeleteAsync(id);

    private static void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FullName))
            throw new ArgumentException("User full name is required.");

        if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains('@'))
            throw new ArgumentException("Correct user email is required.");
    }
}
