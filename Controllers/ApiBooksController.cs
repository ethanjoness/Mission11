using Microsoft.AspNetCore.Mvc;
using BookstoreApp.Data;
using BookstoreApp.Models;

namespace BookstoreApp.Controllers;

[ApiController]
[Route("api/books")]
public class ApiBooksController : ControllerBase
{
    private IBookstoreRepository _repo;
    public ApiBooksController(IBookstoreRepository temp) => _repo = temp;

    [HttpGet]
    public IActionResult Get() => Ok(_repo.Books);

    [HttpPost]
    public IActionResult Post([FromBody] Book book)
    {
        _repo.AddBook(book);
        return Ok(book);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Book book)
    {
        book.BookID = id;
        _repo.UpdateBook(book);
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _repo.Books.FirstOrDefault(b => b.BookID == id);
        if (book != null)
        {
            _repo.DeleteBook(book);
            return Ok();
        }
        return NotFound();
    }
}