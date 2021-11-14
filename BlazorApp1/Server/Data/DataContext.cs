using Microsoft.EntityFrameworkCore;
using BlazorApp1.Shared;

namespace BlazorApp1.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TestData> TestTable { get; set; }

    }
}
