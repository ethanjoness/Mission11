namespace BookstoreApp.Models.ViewModels;

public class BookListViewModel
{
    public IQueryable<Book> Books { get; set; } = Enumerable.Empty<Book>().AsQueryable();
    public PagingInfo PagingInfo { get; set; } = new();
    public string? CurrentCategory { get; set; }
    public string CurrentSort { get; set; } = "title_asc";
}