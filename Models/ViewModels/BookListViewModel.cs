namespace BookstoreApp.Models.ViewModels;

public class BookListViewModel
{
    // Initialize with an empty queryable to prevent the warning
    public IQueryable<Book> Books { get; set; } = Enumerable.Empty<Book>().AsQueryable();
    
    public PagingInfo PagingInfo { get; set; } = new();
    
    // Use 'required' or initialize with string.Empty
    public required string CurrentSort { get; set; }
}