using Kon.BillingBash.Groups.Entities;
using Kon.BillingBash.Groups.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Kon.BillingBash.Application.AppServices;

public class GroupAppService : BillingBashAppService, IGroupAppService
{
	private readonly IUserGroupRepository _userGroupRepository;

	public GroupAppService(IUserGroupRepository userGroupRepository)
	{
		_userGroupRepository = userGroupRepository;
	}

	public async Task<List<IdentityUserDto>> GetListUserAsync(Guid groupId)
	{
		var userGroup = await AsyncExecuter.FirstOrDefaultAsync(await _userGroupRepository.WithDetailsAsync(x => x.Users));
		if (userGroup == null)
		{
			throw new EntityNotFoundException(typeof(UserGroup), groupId);
		}

		return ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(userGroup.Users.ToList());
	}
}