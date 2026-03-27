using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookstoreApp.Data;
using BookstoreApp.Models;
using BookstoreApp.Infrastructure;

namespace BookstoreApp.Pages;

public class CartModel : PageModel
{
    private IBookstoreRepository _repo;

    public CartModel(IBookstoreRepository temp, Cart cartService)
    {
        _repo = temp;
        Cart = cartService;
    }

    public Cart Cart { get; set; }
    public string ReturnUrl { get; set; } = "/";

    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
    }

    public IActionResult OnPost(int bookId, string returnUrl)
    {
        Book? b = _repo.Books.FirstOrDefault(x => x.BookID == bookId);

        if (b != null)
        {
            Cart.AddItem(b, 1);
        }

        return RedirectToPage(new { returnUrl = returnUrl });
    }
}