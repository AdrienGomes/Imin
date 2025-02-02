using IMINBackend.Contracts.Services;
using IMINBackend.Services.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace IMINBackend.Services.Services.Bootstrap;

/// <summary>
/// Service to bootstrap the <see cref="IminDbContext"/>
/// </summary>
public class DbBootstrapService(IminDbContext context) : IAppBootstrapService
{

    /// <inheritdoc/>
    public async Task DoAsync() => await ApplyEfMigration();

    /// <summary>
    /// Apply EF migrations
    /// </summary>
    /// <remarks>
    /// This methods only apply migrations, adding migration is done manually by dev. See EF tool add migration doc
    /// </remarks>
    async Task ApplyEfMigration()
    {

        // TODO : should move to Ilogger
        Console.WriteLine("Applying EF migrations");

        try
        {
            await context.Database.MigrateAsync();

            // TODO : should move to Ilogger
            Console.WriteLine("EF migrations succesfully applied");

        }
        catch (Exception ex)
        {
            // TODO : should move to Ilogger
            Console.WriteLine($"An exception has occured during Ef migrations : {ex}");
        }
    }
}
