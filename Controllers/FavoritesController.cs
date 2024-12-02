using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Data;
using BookLibraryApp.Models;

namespace BookLibraryApp.Controllers
{
    [Authorize]
    public class FavouritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public FavouritesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Get the current user's ID
            var userId = _userManager.GetUserId(User);

            var favourites = await _context.Favourites
                .Include(f => f.Book)
                .Where(f => f.UserId == userId)
                .ToListAsync();

            return View(favourites);
        }

        public async Task<IActionResult> Like(int bookId)
        {
            // Get the current user's ID
            var userId = _userManager.GetUserId(User);

            // Check if the favourite already exists
            var existingFavourite = await _context.Favourites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.BookId == bookId);

            if (existingFavourite == null)
            {
                var favourite = new Favourite { UserId = userId, BookId = bookId };
                _context.Favourites.Add(favourite);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Books");
        }
    }
}
