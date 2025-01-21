using Microsoft.EntityFrameworkCore;

namespace IMINBackend.Services.Repositories.Context
{
    /// <summary>
    /// Db context to manipulate data base through EF 
    /// </summary>
    public class IminDbContext(DbContextOptions options) : DbContext(options)
    {
    }
}
