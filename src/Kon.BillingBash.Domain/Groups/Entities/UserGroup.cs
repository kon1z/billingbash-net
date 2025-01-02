using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Kon.BillingBash.Groups.Entities;

public class UserGroup : AggregateRoot<Guid>
{
	public UserGroup(string name)
	{
		Name = name;
	}

	public string Name { get; set; }

	public virtual ICollection<IdentityUser> Users { get; set; } = new List<IdentityUser>();
}
