using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibHub.Authorization.Roles;
using LibHub.Authorization.Users;
using LibHub.MultiTenancy;
using LibHub.Domain.Category;
using LibHub.Domain.Users;
using LibHub.Domain.BookRequest;
using LibHub.Domain.Books;
using LibHub.Domain.Booking;

namespace LibHub.EntityFrameworkCore
{
    public class LibHubDbContext : AbpZeroDbContext<Tenant, Role, User, LibHubDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRequest> BookRequests { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Librarian> Librarians { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Space> Spaces { get; set; }




        
        public LibHubDbContext(DbContextOptions<LibHubDbContext> options)
            : base(options)
        {
        }
    }
}
