using Kon.BillingBash.Bills.Entities;
using Kon.BillingBash.Groups.Entities;
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

			b.HasMany(x => x.Joiners).WithMany().UsingEntity(BillingBashConsts.DbTablePrefix + "BillJoiner" + BillingBashConsts.DbSchema);

			b.ApplyObjectExtensionMappings();
		});

		builder.Entity<UserGroup>(b =>
		{
			b.ToTable(BillingBashConsts.DbTablePrefix + "UserGroup" + BillingBashConsts.DbSchema);
			b.ConfigureByConvention();

			b.HasMany(x => x.Users).WithMany().UsingEntity(BillingBashConsts.DbTablePrefix + "UserGroupJoiner" + BillingBashConsts.DbSchema);

			b.ApplyObjectExtensionMappings();
		});
	}
}
