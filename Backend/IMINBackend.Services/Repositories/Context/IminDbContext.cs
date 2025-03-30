using IMINBackend.Services.Model.Account;
using IMINBackend.Services.Model.Association;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IMINBackend.Services.Repositories.Context;

/// <summary>
/// Db context to manipulate data base through EF 
/// </summary>
public class IminDbContext(DbContextOptions<IminDbContext> options) : DbContext(options)
{
    #region Tables
    /// <summary> The "User" table </summary>
    public DbSet<User> Users { get; set; }

    /// <summary> The "AccessAccount" table </summary>
    public DbSet<AccessAccount> AccessAccounts { get; set; }

    /// <summary> The "Volunteer" table </summary>
    public DbSet<Volunteer> Volunteers { get; set; }

    /// <summary> The "PoleMembership" table </summary>
    public DbSet<PoleMembership> PoleMemberships { get; set; }

    /// <summary> The "Pole" table </summary>
    public DbSet<Pole> Poles { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // EF should be able to infer this.
        // I would like to be sure that it does it correctly

        // Access Account -> User
        modelBuilder.Entity<AccessAccount>()
            .HasOne(aa => aa.User)
            .WithMany()
            .HasForeignKey(aa => aa.UserId)
            .IsRequired();

        // PoleMembership -> Pole
        modelBuilder.Entity<PoleMembership>()
            .HasOne(pm => pm.Pole)
            .WithMany()
            .HasForeignKey(pm => pm.PoleId)
            .IsRequired();

        // PoleMembership -> Volunteer
        modelBuilder.Entity<PoleMembership>()
            .HasOne(pm => pm.Volunteer)
            .WithMany()
            .HasForeignKey(pm => pm.VolunteerId)
            .IsRequired();

        // Volunteer -> User
        modelBuilder.Entity<Volunteer>()
            .HasOne(v => v.User)
            .WithOne(u => u.Volunteer)
            .HasForeignKey<Volunteer>(v => v.UserId)
            .IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
}

// Place this in the same file as your IminDbContext or in a separate file
public class IminDbContextFactory : IDesignTimeDbContextFactory<IminDbContext>
{
    public IminDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IminDbContext>();

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