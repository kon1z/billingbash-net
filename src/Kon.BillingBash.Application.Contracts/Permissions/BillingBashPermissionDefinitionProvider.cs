using Kon.BillingBash.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Kon.BillingBash.Permissions;

public class BillingBashPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BillingBashPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BillingBashPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BillingBashResource>(name);
    }
}
