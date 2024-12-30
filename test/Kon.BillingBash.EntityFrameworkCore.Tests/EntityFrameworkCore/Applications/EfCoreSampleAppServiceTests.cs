using Kon.BillingBash.Samples;
using Xunit;

namespace Kon.BillingBash.EntityFrameworkCore.Applications;

[Collection(BillingBashTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BillingBashEntityFrameworkCoreTestModule>
{

}
