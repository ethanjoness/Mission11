using BookstoreApp.Models;

namespace BookstoreApp.Data;

public class EFBookstoreRepository : IBookstoreRepository
{
    private BookstoreContext _context;
    public EFBookstoreRepository(BookstoreContext temp) => _context = temp;
    
    public IQueryable<Book> Books => _context.Books;

    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void UpdateBook(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }

    public void DeleteBook(Book book)
    {
        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}