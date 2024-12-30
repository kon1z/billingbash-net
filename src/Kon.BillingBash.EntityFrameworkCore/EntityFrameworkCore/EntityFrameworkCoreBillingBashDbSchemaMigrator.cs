using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Kon.BillingBash.Data;
using Volo.Abp.DependencyInjection;

namespace Kon.BillingBash.EntityFrameworkCore;

public class EntityFrameworkCoreBillingBashDbSchemaMigrator
    : IBillingBashDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBillingBashDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the BillingBashDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BillingBashDbContext>()
            .Database
            .MigrateAsync();
    }
}
