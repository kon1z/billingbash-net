using Kon.BillingBash.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Kon.BillingBash.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BillingBashController : AbpControllerBase
{
    protected BillingBashController()
    {
        LocalizationResource = typeof(BillingBashResource);
    }
}
