using Volo.Abp.Modularity;

namespace Kon.BillingBash;

[DependsOn(
    typeof(BillingBashDomainModule),
    typeof(BillingBashTestBaseModule)
)]
public class BillingBashDomainTestModule : AbpModule
{

}
