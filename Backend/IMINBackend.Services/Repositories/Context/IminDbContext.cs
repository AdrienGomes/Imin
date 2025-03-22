using IMINBackend.Services.Model.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IMINBackend.Services.Repositories.Context;

/// <summary>
/// Db context to manipulate data base through EF 
/// </summary>
public class IminDbContext(DbContextOptions<IminDbContext> options) : DbContext(options)
{
    /// <summary>
    /// The "User" table
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// The "AccessAccount" table
    /// </summary>
    public DbSet<AccessAccount> AccessAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // EF should be able to infer this.
        // I would like to be sure that it does it correctly
        modelBuilder.Entity<AccessAccount>()
            .HasOne(aa => aa.User)
            .WithMany()
            .HasForeignKey(aa => aa.UserId);
    }
}

// Place this in the same file as your IminDbContext or in a separate file
public class IminDbContextFactory : IDesignTimeDbContextFactory<IminDbContext>
{
    public IminDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IminDbContext>();

        // Hard-coded connection string just for migrations
        optionsBuilder.UseNpgsql("Host=localhost;Database=your_db;Username=your_user;Password=your_password");

        // OR read from configuration
        var configuration = new ConfigurationManager()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var postgresSection = configuration.GetSection("Postgres");
        var connectionString = $"Host={postgresSection["Host"]};Database={postgresSection["DbName"]};Username={postgresSection["Username"]};Password={postgresSection["Password"]}";

        optionsBuilder.UseNpgsql(connectionString);

        return new IminDbContext(optionsBuilder.Options);
    }
}