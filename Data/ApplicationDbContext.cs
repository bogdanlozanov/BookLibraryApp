using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Models;
using Microsoft.AspNetCore.Identity;

namespace BookLibraryApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // var hasher = new PasswordHasher<User>();

            // modelBuilder.Entity<User>().HasData(
            //     new User
            //     {
            //         Id = "1",
            //         UserName = "admin",
            //         NormalizedUserName = "ADMIN",
            //         Email = "admin@example.com",
            //         NormalizedEmail = "ADMIN@EXAMPLE.COM",
            //         EmailConfirmed = true,
            //         PasswordHash = hasher.HashPassword(null, "Admin@123") // Set a default password
            //     }
            // );

            // // Seed Books
            // modelBuilder.Entity<Book>().HasData(
            //     new Book
            //     {
            //         Id = 1,
            //         Title = "To Kill a Mockingbird",
            //         Author = "Harper Lee",
            //         Description = "A novel about the injustices of race and class in the Deep South.",
            //         Genre = "Fiction",
            //         PublishedDate = new DateTime(1960, 7, 11)
            //     },
            //     new Book
            //     {
            //         Id = 2,
            //         Title = "1984",
            //         Author = "George Orwell",
            //         Description = "A dystopian novel about totalitarian government surveillance and control.",
            //         Genre = "Dystopian",
            //         PublishedDate = new DateTime(1949, 6, 8)
            //     },
            //     new Book
            //     {
            //         Id = 3,
            //         Title = "Moby Dick",
            //         Author = "Herman Melville",
            //         Description = "The epic tale of Captain Ahab's quest to avenge the white whale.",
            //         Genre = "Adventure",
            //         PublishedDate = new DateTime(1851, 10, 18)
            //     }
            // );

            // Define the relationship between Favourite and User
            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favourites)
                .HasForeignKey(f => f.UserId);

            // Define the relationship between Favourite and Book
            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.Book)
                .WithMany()
                .HasForeignKey(f => f.BookId);
        }
    }
}
