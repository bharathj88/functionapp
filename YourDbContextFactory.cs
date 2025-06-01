using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

public class YourDbContextFactory : IDesignTimeDbContextFactory<YourDbContext>
{
    public YourDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<YourDbContext>();
        // Use the same connection string as in local.settings.json or set your own for design-time
        var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString") ??
            "Server=tcp:youtubesongs.database.windows.net,1433;Initial Catalog=youtubesongs;Persist Security Info=False;User ID=bharathj88;Password=Murugan2110$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        optionsBuilder.UseSqlServer(connectionString);
        return new YourDbContext(optionsBuilder.Options);
    }
}
