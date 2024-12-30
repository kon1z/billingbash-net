using Xunit;

namespace Kon.BillingBash.EntityFrameworkCore;

[CollectionDefinition(BillingBashTestConsts.CollectionDefinitionName)]
public class BillingBashEntityFrameworkCoreCollection : ICollectionFixture<BillingBashEntityFrameworkCoreFixture>
{

}
