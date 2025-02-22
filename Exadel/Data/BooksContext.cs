using Exadel.Requests;
using Microsoft.EntityFrameworkCore;

namespace Exadel.Data
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }
        
    }
}
