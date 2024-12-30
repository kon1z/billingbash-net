using Volo.Abp.Modularity;

namespace Kon.BillingBash;

/* Inherit from this class for your domain layer tests. */
public abstract class BillingBashDomainTestBase<TStartupModule> : BillingBashTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
