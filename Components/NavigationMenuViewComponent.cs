using Microsoft.AspNetCore.Mvc;
using BookstoreApp.Data;

namespace BookstoreApp.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private IBookstoreRepository _repo;
    public NavigationMenuViewComponent(IBookstoreRepository temp) => _repo = temp;

    public IViewComponentResult Invoke()
    {
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        
        var categories = _repo.Books
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            
        return View(categories);
    }
}