using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kon.BillingBash.Bills.Entities;
using Kon.BillingBash.Bills.Repositories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.BillingBash.EntityFrameworkCore.Repositories;

public class ConsumptionRecordRepository : BillingBashEfCoreRepository<ConsumptionRecord, long>, IConsumptionRecordRepository
{
	public ConsumptionRecordRepository(IDbContextProvider<BillingBashDbContext> dbContextProvider) : base(dbContextProvider)
	{

	}

	public async Task<(List<ConsumptionRecord> ConsumptionRecords, long TotalCount)> GetListConsumptionRecordAsync(
		int skipCount,
		int maxResultCount,
		string? sorting,
		bool includeDetails = false,
		CancellationToken cancellationToken = default)
	{
		var queryable = includeDetails
			? await WithDetailsAsync()
			: await GetQueryableAsync();

		var consumptionRecords = await queryable
			.OrderByIf<ConsumptionRecord, IQueryable<ConsumptionRecord>>(!sorting.IsNullOrWhiteSpace(), sorting)
			.PageBy(skipCount, maxResultCount)
			.ToListAsync(GetCancellationToken(cancellationToken));
		var totalCount = await queryable.LongCountAsync(cancellationToken: cancellationToken);

		return (consumptionRecords, totalCount);
	}
}
