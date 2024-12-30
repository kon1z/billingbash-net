using Volo.Abp.Settings;

namespace Kon.BillingBash.Settings;

public class BillingBashSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BillingBashSettings.MySetting1));
    }
}
