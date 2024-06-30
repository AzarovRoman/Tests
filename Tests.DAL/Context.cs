using Microsoft.EntityFrameworkCore;
using Tests.DAL.Entities;

namespace Tests.DAL
{
    public class Context : DbContext
    {
        // db tables
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
