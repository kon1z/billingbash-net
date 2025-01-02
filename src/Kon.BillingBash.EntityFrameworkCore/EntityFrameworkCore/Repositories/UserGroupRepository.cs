using Kon.BillingBash.Groups.Entities;
using Kon.BillingBash.Groups.Repositories;
using System;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.BillingBash.EntityFrameworkCore.Repositories;

public class UserGroupRepository : BillingBashEfCoreRepository<UserGroup, Guid>, IUserGroupRepository
{
	public UserGroupRepository(IDbContextProvider<BillingBashDbContext> dbContextProvider) : base(dbContextProvider)
	{
	}
}
