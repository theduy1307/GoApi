using Microsoft.EntityFrameworkCore;
using Npgsql;
using Polly;

namespace MasterData.Api.Extensions;

public static class DbExtension
{
    public static IHost MigrationDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder)
        where TContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();
            try
            {
                logger.LogInformation($"Starter Db Migration: {typeof(TContext).Name}");
                // retry strategy
                var retry = Policy.Handle<NpgsqlException>()
                    .WaitAndRetry(
                        retryCount: 5,
                        sleepDurationProvider: retryAttemp => TimeSpan.FromSeconds(Math.Pow(2, retryAttemp)),
                        onRetry:
                        (exception, span, count) =>
                        {
                            logger.LogError($"Retrying because of {exception} {span}");   
                        });
                retry.Execute(() => CallSeeder(seeder, context, services));
                logger.LogInformation($"Migration completed: {typeof(TContext).Name}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occured while migration db: {typeof(TContext).Name}");
            }
        }
        return host;
    }

    private static void CallSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) where TContext : DbContext
    {
        context.Database.Migrate();
        seeder(context, services);
    }
}