// I am taking this from fffffatah:fffffatah/getting-features-from-database-example
using Microsoft.EntityFrameworkCore;

namespace LocalFeatureFlag.Database;

public class SqliteDbContext : DbContext
{
    public DbSet<Feature> Features { get; set; } = null!;

    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feature>().HasKey(f => f.Name);
    }
}
