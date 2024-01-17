using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData
{
    //DbContext provides EF Core's database connectivity and tracks changes to objects.
    public class PubContext : DbContext
    {
        //DbSet wraps the classess that EF Core will work with.
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        //We will hardcode the connection string for demo.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //The UseNpgsql extension method is provided by Npgsql.EntityFrameworkCore.PostgreSQL provider
            optionsBuilder.UseNpgsql("Host=localhost;Database=pubDatabase;Username=postgres;Password=postgres;Port=5433");
        }
    }
    
}
