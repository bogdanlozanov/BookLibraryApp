using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using BookLibraryApp.Models;

namespace BookLibraryApp.Data
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book { Title = "Book 1", Author = "Author 1", Description = "Description 1", Genre = "Fiction", PublishedDate = DateTime.Now.AddYears(-10) },
                    new Book { Title = "Book 2", Author = "Author 2", Description = "Description 2", Genre = "Fantasy", PublishedDate = DateTime.Now.AddYears(-9) },
                    new Book { Title = "Book 3", Author = "Author 3", Description = "Description 3", Genre = "Romance", PublishedDate = DateTime.Now.AddYears(-8) },
                    new Book { Title = "Book 4", Author = "Author 4", Description = "Description 4", Genre = "Mystery", PublishedDate = DateTime.Now.AddYears(-7) },
                    new Book { Title = "Book 5", Author = "Author 5", Description = "Description 5", Genre = "Science Fiction", PublishedDate = DateTime.Now.AddYears(-6) },
                    new Book { Title = "Book 6", Author = "Author 6", Description = "Description 6", Genre = "Thriller", PublishedDate = DateTime.Now.AddYears(-5) },
                    new Book { Title = "Book 7", Author = "Author 7", Description = "Description 7", Genre = "Horror", PublishedDate = DateTime.Now.AddYears(-4) },
                    new Book { Title = "Book 8", Author = "Author 8", Description = "Description 8", Genre = "Non-Fiction", PublishedDate = DateTime.Now.AddYears(-3) },
                    new Book { Title = "Book 9", Author = "Author 9", Description = "Description 9", Genre = "Biography", PublishedDate = DateTime.Now.AddYears(-2) },
                    new Book { Title = "Book 10", Author = "Author 10", Description = "Description 10", Genre = "Adventure", PublishedDate = DateTime.Now.AddYears(-1) },
                    new Book { Title = "Book 11", Author = "Author 11", Description = "Description 11", Genre = "Drama", PublishedDate = DateTime.Now.AddYears(-10) },
                    new Book { Title = "Book 12", Author = "Author 12", Description = "Description 12", Genre = "Comedy", PublishedDate = DateTime.Now.AddYears(-9) },
                    new Book { Title = "Book 13", Author = "Author 13", Description = "Description 13", Genre = "Historical", PublishedDate = DateTime.Now.AddYears(-8) },
                    new Book { Title = "Book 14", Author = "Author 14", Description = "Description 14", Genre = "Fantasy", PublishedDate = DateTime.Now.AddYears(-7) },
                    new Book { Title = "Book 15", Author = "Author 15", Description = "Description 15", Genre = "Fiction", PublishedDate = DateTime.Now.AddYears(-6) },
                    new Book { Title = "Book 16", Author = "Author 16", Description = "Description 16", Genre = "Horror", PublishedDate = DateTime.Now.AddYears(-5) },
                    new Book { Title = "Book 17", Author = "Author 17", Description = "Description 17", Genre = "Mystery", PublishedDate = DateTime.Now.AddYears(-4) },
                    new Book { Title = "Book 18", Author = "Author 18", Description = "Description 18", Genre = "Thriller", PublishedDate = DateTime.Now.AddYears(-3) },
                    new Book { Title = "Book 19", Author = "Author 19", Description = "Description 19", Genre = "Biography", PublishedDate = DateTime.Now.AddYears(-2) },
                    new Book { Title = "Book 20", Author = "Author 20", Description = "Description 20", Genre = "Science Fiction", PublishedDate = DateTime.Now.AddYears(-1) }
                );

                context.SaveChanges();
            }
        }
    }
}
