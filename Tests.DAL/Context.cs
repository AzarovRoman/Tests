using Microsoft.EntityFrameworkCore;
using Tests.DAL.Entities;

namespace Tests.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        // db tables
        public DbSet<Question> Questions { get; set; }
    }
}
