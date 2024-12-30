using System;
using System.Collections.Generic;
using System.Text;
using Kon.BillingBash.Localization;
using Volo.Abp.Application.Services;

namespace Kon.BillingBash;

/* Inherit your application services from this class.
 */
public abstract class BillingBashAppService : ApplicationService
{
    protected BillingBashAppService()
    {
        LocalizationResource = typeof(BillingBashResource);
    }
}
