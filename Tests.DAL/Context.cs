using Microsoft.EntityFrameworkCore;

namespace Tests.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        // db tables
        // public DbSet<XXX> XXXs { get; set; }
    }
}
