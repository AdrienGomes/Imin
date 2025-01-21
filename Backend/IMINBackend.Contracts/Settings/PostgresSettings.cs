namespace IMINBackend.Contracts.Settings;

/// <summary>
/// Define the structure for postgres settings
/// </summary>
public class PostgresSettings
{
    /// <summary>
    /// The section name
    /// </summary>
    public const string SectionName = "Postgres";

    public string? Host { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? DbName { get; set; }
    public int? MinPoolSize { get; set; }
    public int? MaxPoolSize { get; set; }
    public int? CommandTimeout { get; set; }
}
