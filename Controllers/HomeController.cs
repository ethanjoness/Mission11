using Microsoft.AspNetCore.Mvc;
using BookstoreApp.Data;
using BookstoreApp.Models.ViewModels;

namespace BookstoreApp.Controllers;

public class HomeController : Controller
{
    private IBookstoreRepository _repo;
    public HomeController(IBookstoreRepository temp) => _repo = temp;

    public IActionResult Index(int pageNum = 1, int pageSize = 5, string sortOrder = "title_asc")
    {
        ViewBag.CurrentSort = sortOrder;

        var bookQuery = _repo.Books;

        // Sorting Logic
        bookQuery = sortOrder == "title_desc" 
            ? bookQuery.OrderByDescending(b => b.Title) 
            : bookQuery.OrderBy(b => b.Title);

        var data = new BookListViewModel
        {
            Books = bookQuery
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

            PagingInfo = new PagingInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = _repo.Books.Count()
            },
            CurrentSort = sortOrder
        };

        return View(data);
    }
}