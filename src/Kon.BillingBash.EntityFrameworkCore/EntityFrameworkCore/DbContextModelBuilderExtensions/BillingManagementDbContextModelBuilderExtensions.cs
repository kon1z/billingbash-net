using Kon.BillingBash.Bills.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace Kon.BillingBash.EntityFrameworkCore.DbContextModelBuilderExtensions;

public static class BillingManagementDbContextModelBuilderExtensions
{
	public static void ConfigureBillingManagement(
		this ModelBuilder builder)
	{
		Check.NotNull(builder, nameof(builder));
		if (builder.IsTenantOnlyDatabase())
		{
			return;
		}

		builder.Entity<ConsumptionRecord>(b =>
		{
			b.ToTable(BillingBashConsts.DbTablePrefix + "Bill" + BillingBashConsts.DbSchema);
			b.ConfigureByConvention();

			b.HasMany<IdentityUser>().WithMany().UsingEntity(BillingBashConsts.DbTablePrefix + "BillJoiners" + BillingBashConsts.DbSchema);

			b.ApplyObjectExtensionMappings();
		});
	}
}
