using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public sealed class OrderService
{
    private readonly IRepository<Order> _orders;
    private readonly IRepository<User> _users;
    private readonly IRepository<Book> _books;

    public OrderService(IRepository<Order> orders, IRepository<User> users, IRepository<Book> books)
    {
        _orders = orders;
        _users = users;
        _books = books;
    }

    public List<Order> GetAll() => _orders.GetAll();
    public Task<List<Order>> GetAllAsync() => _orders.GetAllAsync();

    public Order? GetById(int id) => _orders.GetById(id);
    public Task<Order?> GetByIdAsync(int id) => _orders.GetByIdAsync(id);

    public Order Add(Order order)
    {
        Validate(order);
        CheckRelatedData(order);
        return _orders.Add(order);
    }

    public async Task<Order> AddAsync(Order order)
    {
        Validate(order);
        await CheckRelatedDataAsync(order);
        return await _orders.AddAsync(order);
    }

    public bool Update(Order order)
    {
        Validate(order);
        CheckRelatedData(order);
        return _orders.Update(order);
    }

    public async Task<bool> UpdateAsync(Order order)
    {
        Validate(order);
        await CheckRelatedDataAsync(order);
        return await _orders.UpdateAsync(order);
    }

    public bool Delete(int id) => _orders.Delete(id);
    public Task<bool> DeleteAsync(int id) => _orders.DeleteAsync(id);

    private static void Validate(Order order)
    {
        if (order.UserId <= 0)
            throw new ArgumentException("User id must be greater than zero.");

        if (order.BookId <= 0)
            throw new ArgumentException("Book id must be greater than zero.");

        if (order.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");
    }

    private void CheckRelatedData(Order order)
    {
        if (_users.GetById(order.UserId) is null)
            throw new InvalidOperationException("User for this order was not found.");

        if (_books.GetById(order.BookId) is null)
            throw new InvalidOperationException("Book for this order was not found.");
    }

    private async Task CheckRelatedDataAsync(Order order)
    {
        if (await _users.GetByIdAsync(order.UserId) is null)
            throw new InvalidOperationException("User for this order was not found.");

        if (await _books.GetByIdAsync(order.BookId) is null)
            throw new InvalidOperationException("Book for this order was not found.");
    }
}
