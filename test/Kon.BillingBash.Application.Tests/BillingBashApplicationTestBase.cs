using Volo.Abp.Modularity;

namespace Kon.BillingBash;

public abstract class BillingBashApplicationTestBase<TStartupModule> : BillingBashTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
