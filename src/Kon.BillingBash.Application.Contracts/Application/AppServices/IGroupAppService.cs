using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Kon.BillingBash.Application.AppServices;

public interface IGroupAppService : IApplicationService
{
	Task<List<IdentityUserDto>> GetListUserAsync(Guid groupId);
}