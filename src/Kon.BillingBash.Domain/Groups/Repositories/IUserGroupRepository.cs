using Kon.BillingBash.Groups.Entities;
using System;
using Volo.Abp.Domain.Repositories;

namespace Kon.BillingBash.Groups.Repositories;

public interface IUserGroupRepository : IRepository<UserGroup, Guid>
{
}
