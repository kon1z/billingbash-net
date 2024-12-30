using Microsoft.Extensions.Localization;
using Kon.BillingBash.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Kon.BillingBash;

[Dependency(ReplaceServices = true)]
public class BillingBashBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BillingBashResource> _localizer;

    public BillingBashBrandingProvider(IStringLocalizer<BillingBashResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
