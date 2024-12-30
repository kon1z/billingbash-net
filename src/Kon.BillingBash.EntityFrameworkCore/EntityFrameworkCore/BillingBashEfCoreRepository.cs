using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.BillingBash.EntityFrameworkCore;

public abstract class BillingBashEfCoreRepository<TEntity, TKey> : EfCoreRepository<BillingBashDbContext, TEntity, TKey>
	where TEntity : class, IEntity<TKey>
{
	protected BillingBashEfCoreRepository(IDbContextProvider<BillingBashDbContext> dbContextProvider) : base(dbContextProvider)
	{
	}
}

public abstract class BillingBashEfCoreRepository<TEntity> : EfCoreRepository<BillingBashDbContext, TEntity> 
	where TEntity : class, IEntity
{
	protected BillingBashEfCoreRepository(IDbContextProvider<BillingBashDbContext> dbContextProvider) : base(dbContextProvider)
	{
	}
}
