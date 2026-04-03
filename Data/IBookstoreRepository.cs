using BookstoreApp.Models;

namespace BookstoreApp.Data;

public interface IBookstoreRepository
{
    IQueryable<Book> Books { get; }
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
}