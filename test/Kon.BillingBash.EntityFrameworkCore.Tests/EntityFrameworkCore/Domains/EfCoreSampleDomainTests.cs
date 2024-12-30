using Kon.BillingBash.Samples;
using Xunit;

namespace Kon.BillingBash.EntityFrameworkCore.Domains;

[Collection(BillingBashTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BillingBashEntityFrameworkCoreTestModule>
{

}
