using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// Removed invalid using directive for Microsoft.EntityFrameworkCore.Relational

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
    {
    }

    // Define your DbSet properties here, for example:
    // DbSet for Songs table
    public DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity relationships, constraints, etc.
        modelBuilder.Entity<Song>().ToTable("Songs"); // Map to Songs table
        base.OnModelCreating(modelBuilder);
    }
}