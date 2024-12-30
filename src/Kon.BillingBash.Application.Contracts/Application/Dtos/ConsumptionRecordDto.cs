using System;
using System.Collections.Generic;
using Kon.BillingBash.Bills.Enums;
using Volo.Abp.Application.Dtos;

namespace Kon.BillingBash.Application.Dtos;

public class ConsumptionRecordDto : EntityDto<long>
{
	/// <summary>
	/// 消费日期
	/// </summary>
	public DateTime ConsumptionDate { get; set; }

	/// <summary>
	/// 消费金额
	/// </summary>
	public decimal ConsumptionAmount { get; set; }

	/// <summary>
	/// 消费类型
	/// </summary>
	public string? ConsumptionType { get; set; }

	/// <summary>
	/// 商家信息
	/// </summary>
	public string? MerchantInformation { get; set; }

	/// <summary>
	/// 商品或服务详情
	/// </summary>
	public string Product { get; set; }

	/// <summary>
	/// 备注 
	/// </summary>
	public string? Remarks { get; set; }

	/// <summary>
	/// 分类标签
	/// </summary>
	public string? ClassificationTag { get; set; }

	/// <summary>
	/// 支付方式
	/// </summary>
	public PaymentMethod PaymentMethod { get; set; }

	public List<Guid> JoinerUserId { get; set; } = new();
}