using SchoolLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolLibrary.ConsoleApp.Controllers;

public class BooksController : Controller
{
    private readonly BookService _service;

    public BooksController(BookService service)
    {
        _service = service;
    }

    // GET /Books
    public IActionResult Index()
    {
        var books = _service.GetAllBooks();
        return View(books);
    }

    // POST /Books/Borrow/2
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Borrow(int id)
    {
        TempData["Message"] = _service.BorrowBook(id);
        return RedirectToAction(nameof(Index));
    }

    // POST /Books/Return/2
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Return(int id)
    {
        TempData["Message"] = _service.ReturnBook(id);
        return RedirectToAction(nameof(Index));
    }
}