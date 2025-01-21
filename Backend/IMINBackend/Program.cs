ILogger<Program>? _logger = null;
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Add standards controllers
    builder.Services.AddControllers();

    // OpenAPI
    builder.Services.AddOpenApi();

    builder.Configuration.ConfigurePostgresSettings(builder.Environment.IsDevelopment());
    builder.Services.Configure<string>(builder.Configuration.GetSection("PostgresSettings.SectionName"));

    // Add common services
    builder.Services.AddServices(builder.Configuration);

    // Swagger services
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    // ###################
    // ### MIDLLEWARES ###
    // ###################
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception e)
{
    /// Logger need to be injected at this point
    if (_logger != null)
    {
        _logger.LogError(e, "Unexpected error during error");
        Environment.Exit(1);
    }
}


static class ProgramExtension
{
    /// <summary>
    /// Merge the docker secrets for db settings with appsettings.json values
    /// </summary>
    public static ConfigurationManager ConfigurePostgresSettings(this ConfigurationManager builder, bool isDev)
    {
        builder.AddKeyPerFile("/run/secrets", isDev);
        var secretDbName = builder.GetValue<string>("postgres_db_name");
        if (secretDbName != null)
            builder.GetSection("Postgres")["DbName"] = secretDbName;
        var secretUsername = builder.GetValue<string>("postgres_username");
        if (secretUsername != null)
            builder.GetSection("Postgres")["Username"] = secretUsername;
        var secretpassword = builder.GetValue<string>("postgres_password");
        if (secretpassword != null)
            builder.GetSection("Postgres")["Password"] = secretpassword;

        return builder;
    }
}