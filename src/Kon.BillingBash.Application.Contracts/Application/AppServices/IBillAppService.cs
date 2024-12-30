using System.Threading.Tasks;
using Kon.BillingBash.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kon.BillingBash.Application.AppServices;

public interface IBillAppService : IApplicationService
{
	Task<PagedResultDto<ConsumptionRecordDto>> GetListConsumptionRecordAsync(GetListConsumptionRecordRequest request);
	Task<ConsumptionRecordDto> CreateConsumptionRecordAsync(CreateConsumptionRecordRequest request);
	Task DeleteConsumptionAsync(long id);
}