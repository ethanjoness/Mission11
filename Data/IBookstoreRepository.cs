using BookstoreApp.Models;

namespace BookstoreApp.Data;

public interface IBookstoreRepository
{
    IQueryable<Book> Books { get; }
}