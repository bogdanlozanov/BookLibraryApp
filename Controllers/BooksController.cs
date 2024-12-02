using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Data;
using BookLibraryApp.Models;

namespace BookLibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Home view - List of books
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }
    }
}
