using Microsoft.EntityFrameworkCore;

namespace TestSQLUpdateSpeed
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=MyTestDB;Trusted_Connection=True;");
        }

        public DbSet<Test>? Tests { get; set; }
    }
}
