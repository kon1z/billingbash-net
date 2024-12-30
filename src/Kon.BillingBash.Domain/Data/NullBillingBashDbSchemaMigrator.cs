using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Kon.BillingBash.Data;

/* This is used if database provider does't define
 * IBillingBashDbSchemaMigrator implementation.
 */
public class NullBillingBashDbSchemaMigrator : IBillingBashDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
