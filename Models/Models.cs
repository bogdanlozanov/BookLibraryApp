using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Initialize with default value
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
    }


    public class User : IdentityUser
    {
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    }

    public class Favourite
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty; // Default value
        public int BookId { get; set; }
        public User User { get; set; } = null!;
        public Book Book { get; set; } = null!;
    }

    public class Role : IdentityRole
    {
        // Add custom properties for roles if necessary
    }

    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }


    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }

}
