using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;

namespace AsyncDataLibrary.Services;

public sealed class BookService
{
    private readonly IRepository<Book> _books;

    public BookService(IRepository<Book> books)
    {
        _books = books;
    }

    public List<Book> GetAll() => _books.GetAll();
    public Task<List<Book>> GetAllAsync() => _books.GetAllAsync();

    public Book? GetById(int id) => _books.GetById(id);
    public Task<Book?> GetByIdAsync(int id) => _books.GetByIdAsync(id);

    public Book Add(Book book)
    {
        Validate(book);
        return _books.Add(book);
    }

    public async Task<Book> AddAsync(Book book)
    {
        Validate(book);
        return await _books.AddAsync(book);
    }

    public bool Update(Book book)
    {
        Validate(book);
        return _books.Update(book);
    }

    public Task<bool> UpdateAsync(Book book)
    {
        Validate(book);
        return _books.UpdateAsync(book);
    }

    public bool Delete(int id) => _books.Delete(id);
    public Task<bool> DeleteAsync(int id) => _books.DeleteAsync(id);

    private static void Validate(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            throw new ArgumentException("Book title is required.");

        if (string.IsNullOrWhiteSpace(book.Author))
            throw new ArgumentException("Book author is required.");

        if (book.Year < 0)
            throw new ArgumentException("Book year cannot be negative.");

        if (book.Price < 0)
            throw new ArgumentException("Book price cannot be negative.");
    }
}
