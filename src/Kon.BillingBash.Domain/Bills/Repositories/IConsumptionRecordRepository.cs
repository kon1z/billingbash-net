using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kon.BillingBash.Bills.Entities;
using Volo.Abp.Domain.Repositories;

namespace Kon.BillingBash.Bills.Repositories;

public interface IConsumptionRecordRepository : IBasicRepository<ConsumptionRecord, long>
{
	Task<(List<ConsumptionRecord> ConsumptionRecords, long TotalCount)> GetListConsumptionRecordAsync(int skipCount,
		int maxResultCount,
		string? sorting,
		bool includeDetails = false,
		CancellationToken cancellationToken = default);
}
