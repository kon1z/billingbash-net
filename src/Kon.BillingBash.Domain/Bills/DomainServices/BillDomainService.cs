using Kon.BillingBash.Bills.Entities;
using Kon.BillingBash.Bills.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace Kon.BillingBash.Bills.DomainServices;

public class BillDomainService : DomainService
{
	private readonly IConsumptionRecordRepository _consumptionRecordRepository;
	private readonly IIdentityUserRepository _identityUserRepository;

	public BillDomainService(IConsumptionRecordRepository consumptionRecordRepository,
		IIdentityUserRepository identityUserRepository)
	{
		_consumptionRecordRepository = consumptionRecordRepository;
		_identityUserRepository = identityUserRepository;
	}

	public async Task CreateConsumptionRecord(ConsumptionRecord consumptionRecord, List<Guid> joinerIds)
	{
		var joiners = await _identityUserRepository.GetListByIdsAsync(joinerIds);

		consumptionRecord.Joiner.AddRange(joiners);

		await _consumptionRecordRepository.InsertAsync(consumptionRecord);
	}

	public Task DeleteConsumptionAsync(long id)
	{
		return _consumptionRecordRepository.DeleteAsync(id);
	}
}
