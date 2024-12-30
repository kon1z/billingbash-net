using Volo.Abp.Modularity;

namespace Kon.BillingBash;

[DependsOn(
    typeof(BillingBashApplicationModule),
    typeof(BillingBashDomainTestModule)
)]
public class BillingBashApplicationTestModule : AbpModule
{

}
