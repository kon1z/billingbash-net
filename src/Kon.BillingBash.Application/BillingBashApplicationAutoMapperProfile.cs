using AutoMapper;
using Kon.BillingBash.Application.Dtos;
using Kon.BillingBash.Bills.Entities;

namespace Kon.BillingBash;

public class BillingBashApplicationAutoMapperProfile : Profile
{
    public BillingBashApplicationAutoMapperProfile()
    {
	    CreateMap<ConsumptionRecord, ConsumptionRecordDto>();
    }
}
