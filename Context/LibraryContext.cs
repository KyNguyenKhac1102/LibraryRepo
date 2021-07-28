
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.UserId).ValueGeneratedOnAdd();
            modelBuilder.Entity<BookBorrowingRequest>().Property(x => x.RequestId).ValueGeneratedOnAdd();
            modelBuilder.Entity<BookBorrowingRequestDetail>().Property(x => x.DetailId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(x => x.BookId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(x => x.CategoryId).ValueGeneratedOnAdd();


            modelBuilder.Entity<User>().HasMany(p => p.UserRequests).WithOne(b => b.User).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(p => p.SuperUserRequests).WithOne(b => b.SuperUser).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BookBorrowingRequest>().HasMany(p => p.BookBorrowingRequestDetails).WithOne(b => b.BookBorrowingRequest).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Book>().HasMany(p => p.BookBorrowingRequestDetails).WithOne(b => b.Book).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Book>().HasMany(p => p.Categories).WithOne(b => b.Book).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Username = "dsa", Email = "xxx@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("dsa"), Admin = true });

            modelBuilder.Entity<User>().HasData(
            new User { UserId = 2, Username = "dsa1", Email = "xxx1@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("dsa"), Admin = false });

            modelBuilder.Entity<BookBorrowingRequest>().HasData(
            new BookBorrowingRequest { RequestId = 1, SuperUserId = 1, Date = System.DateTime.Now, BookStatus = Status.Rejected, UserId = 2 });

            modelBuilder.Entity<Book>().HasData(
            new Book { BookId = 1, BookName = "Game Of Throne" });

            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Fantasy", BookId = 1 });
        }
        public DbSet<Book> Books { get; set; }

        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }
    }
}