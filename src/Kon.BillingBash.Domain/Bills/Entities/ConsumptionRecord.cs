using System;
using System.Collections.Generic;
using Kon.BillingBash.Bills.Enums;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Kon.BillingBash.Bills.Entities;

public class ConsumptionRecord : AggregateRoot<long>
{
	public ConsumptionRecord(DateTime consumptionDate,
		decimal consumptionAmount,
		string product,
		PaymentMethod paymentMethod,
		string? consumptionType = null,
		string? merchantInformation = null,
		string? remarks = null,
		string? classificationTag = null)
	{
		ConsumptionDate = consumptionDate;
		ConsumptionAmount = consumptionAmount;
		ConsumptionType = consumptionType;
		MerchantInformation = merchantInformation;
		Product = product;
		Remarks = remarks;
		ClassificationTag = classificationTag;
		PaymentMethod = paymentMethod;
	}

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

	/// <summary>
	/// 参与人
	/// </summary>
	public virtual List<IdentityUser> Joiner { get; set; } = new();
}