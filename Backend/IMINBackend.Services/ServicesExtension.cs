using IMINBackend.Contracts.Services;
using IMINBackend.Contracts.Settings;
using IMINBackend.Services.Repositories.Context;
using IMINBackend.Services.Services.Bootstrap;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

#pragma warning disable IDE0130 // Le namespace ne correspond pas à la structure de dossiers
namespace Microsoft.Extensions.DependencyInjection
#pragma warning restore IDE0130 // Le namespace ne correspond pas à la structure de dossiers
{
    /// <summary>
    /// Extension of <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServicesExtension
    {
        /// <summary>
        /// Add services dedicated to this project
        /// </summary>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<PostgresSettings>(configuration.GetSection(PostgresSettings.SectionName))
                .ConfigureDbContext(configuration)
                .AddBootstrapServices(configuration)
                ;
            return services;
        }

        /// <summary>
        /// Add <see cref="IAppBootstrapService"/>s to the service container
        /// </summary>
        /// <remarks>
        /// This registration must be done right after app builder creation</remarks>
        static IServiceCollection AddBootstrapServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                // db bootstrap serice
                .AddSingleton<IAppBootstrapService, DbBootstrapService>()
                ;
            return services;
        }


        /// <summary>
        /// Configure <see cref="IminDbContext"/>
        /// </summary>
        static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var postgresSettings = configuration.GetPostgresSettings();
            services.AddDbContext<IminDbContext>(
                option => option.UseNpgsql(postgresSettings.GetConnectionString()),
                contextLifetime: ServiceLifetime.Singleton
                );
            return services;
        }

        /// <summary>
        /// Get postgres settings from configuration
        /// </summary>
        static PostgresSettings GetPostgresSettings(this IConfiguration configuration) => configuration.GetSection("Postgres").Get<PostgresSettings>()!;

        /// <summary>
        /// Get the connection string from a <see cref="PostgresSettings"/> instance
        /// </summary>
        static string GetConnectionString(this PostgresSettings settings)
        {
            var builder = new NpgsqlConnectionStringBuilder();

            if (settings.DbName != null) builder.Database = settings.DbName;
            if (settings.Password != null) builder.Password = settings.Password;
            if (settings.Username != null) builder.Username = settings.Username;
            if (settings.Host != null) builder.Host = settings.Host;
            builder.Port = 5432;
            if (settings.MinPoolSize != null) builder.MinPoolSize = settings.MinPoolSize ?? 0;
            if (settings.MaxPoolSize != null) builder.MaxPoolSize = settings.MaxPoolSize ?? 0;
            if (settings.CommandTimeout != null) builder.CommandTimeout = settings.CommandTimeout ?? 0;

            return builder.ToString();
        }

    }
}
