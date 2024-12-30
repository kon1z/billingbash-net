using Kon.BillingBash.Application.Dtos;
using Kon.BillingBash.Bills.DomainServices;
using Kon.BillingBash.Bills.Entities;
using Kon.BillingBash.Bills.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Kon.BillingBash.Application.AppServices;

public class BillAppService : BillingBashAppService, IBillAppService
{
	private readonly IConsumptionRecordRepository _consumptionRecordRepository;
	private readonly BillDomainService _billDomainService;

	public BillAppService(IConsumptionRecordRepository consumptionRecordRepository, BillDomainService billDomainService)
	{
		_consumptionRecordRepository = consumptionRecordRepository;
		_billDomainService = billDomainService;
	}

	public async Task<PagedResultDto<ConsumptionRecordDto>> GetListConsumptionRecordAsync(GetListConsumptionRecordRequest request)
	{
		var (consumptionRecords, totalCount) =
			await _consumptionRecordRepository.GetListConsumptionRecordAsync(request.SkipCount, request.MaxResultCount,
				request.Sorting, true);

		return new PagedResultDto<ConsumptionRecordDto>(totalCount,
			ObjectMapper.Map<List<ConsumptionRecord>, List<ConsumptionRecordDto>>(consumptionRecords));
	}

	public async Task<ConsumptionRecordDto> CreateConsumptionRecordAsync(CreateConsumptionRecordRequest request)
	{
		var consumptionRecord = new ConsumptionRecord(request.ConsumptionDate, request.ConsumptionAmount,
			request.Product, request.PaymentMethod, request.ConsumptionType, request.MerchantInformation,
			request.Remarks, request.ClassificationTag);
		await _billDomainService.CreateConsumptionRecord(consumptionRecord, request.JoinerUserIds);

		return ObjectMapper.Map<ConsumptionRecord, ConsumptionRecordDto>(consumptionRecord);
	}

	public async Task DeleteConsumptionAsync(long id)
	{
		await _billDomainService.DeleteConsumptionAsync(id);
	}
}