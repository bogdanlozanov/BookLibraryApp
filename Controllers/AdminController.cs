using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Data;
using BookLibraryApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; // Changed to use IdentityRole

        public AdminController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Manage Books
        public async Task<IActionResult> ManageBooks()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> EditBook(int id)
        {
            if (id == 0)
            {
                return View(new Book());
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    _context.Books.Add(book);
                }
                else
                {
                    _context.Books.Update(book);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageBooks));
            }

            return View(book);
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManageBooks));
        }

        // Manage Users
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new List<(User user, IList<string> roles)>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles.Add((user, roles));
            }

            return View(userRoles); // Ensure you have a corresponding view for this
        }

        public async Task<IActionResult> ChangeRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                ModelState.AddModelError(string.Empty, $"Role '{roleName}' does not exist.");
                return RedirectToAction(nameof(ManageUsers));
            }

            if (currentRoles.Contains(roleName))
            {
                return RedirectToAction(nameof(ManageUsers)); // User already has the role
            }

            // Remove current roles and add the new one
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, roleName);

            return RedirectToAction(nameof(ManageUsers));
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction(nameof(ManageUsers));
        }
    }
}
