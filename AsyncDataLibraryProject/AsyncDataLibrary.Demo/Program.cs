using AsyncDataLibrary.Infrastructure;
using AsyncDataLibrary.Models;
using AsyncDataLibrary.Repositories;
using AsyncDataLibrary.Services;

var dataFolder = Path.Combine(AppContext.BaseDirectory, "data");

var storageProvider = new FileStorageProvider(dataFolder);
var serializer = new JsonDataSerializer();

var userRepository = new JsonRepository<User>(storageProvider, serializer);
var bookRepository = new JsonRepository<Book>(storageProvider, serializer);
var orderRepository = new JsonRepository<Order>(storageProvider, serializer);

var userService = new UserService(userRepository);
var bookService = new BookService(bookRepository);
var orderService = new OrderService(orderRepository, userRepository, bookRepository);

Console.WriteLine("AsyncDataLibrary demo");
Console.WriteLine("---------------------");

var user = await userService.AddAsync(new User
{
    FullName = "Denys Havrylko",
    Email = "denys@example.com"
});

var book = await bookService.AddAsync(new Book
{
    Title = "Clean Code",
    Author = "Robert Martin",
    Year = 2008,
    Price = 450
});

var order = await orderService.AddAsync(new Order
{
    UserId = user.Id,
    BookId = book.Id,
    Quantity = 1
});

Console.WriteLine($"Created user: {user.Id}. {user.FullName}");
Console.WriteLine($"Created book: {book.Id}. {book.Title}");
Console.WriteLine($"Created order: {order.Id}, userId={order.UserId}, bookId={order.BookId}");

Console.WriteLine();
Console.WriteLine("All users from JSON file:");
var users = await userService.GetAllAsync();
foreach (var item in users)
{
    Console.WriteLine($"{item.Id}. {item.FullName} - {item.Email}");
}
