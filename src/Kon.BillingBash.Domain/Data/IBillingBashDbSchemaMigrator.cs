using System.Threading.Tasks;

namespace Kon.BillingBash.Data;

public interface IBillingBashDbSchemaMigrator
{
    Task MigrateAsync();
}
