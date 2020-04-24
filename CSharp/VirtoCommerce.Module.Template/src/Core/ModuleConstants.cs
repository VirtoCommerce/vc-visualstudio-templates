using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace $safeprojectname$
{
    public static class ModuleConstants
    {
        public static class Security
        {
            public static class Permissions
            {
                public const string Access = "$ext_supersafenamejs$:access";
                public const string Create = "$ext_supersafenamejs$:create";
                public const string Read = "$ext_supersafenamejs$:read";
                public const string Update = "$ext_supersafenamejs$:update";
                public const string Delete = "$ext_supersafenamejs$:delete";

                public static string[] AllPermissions { get; } = { Read, Create, Access, Update, Delete };
        }
        }
    
        public static class Settings
        {
            public static class General
            {
                public static SettingDescriptor $ext_supersafename$Enabled  { get; } = new SettingDescriptor
                {
                    Name = "$ext_supersafename$.$ext_supersafename$Enabled",
                    GroupName = "$ext_supersafename$|General",
                    ValueType = SettingValueType.Boolean,
                    DefaultValue = false
                };

                public static SettingDescriptor $ext_supersafename$Password  { get; } = new SettingDescriptor
                {
                    Name = "$ext_supersafename$.$ext_supersafename$Password",
                    GroupName = "$ext_supersafename$|Advanced",
                    ValueType = SettingValueType.SecureString,
                    DefaultValue = "qwerty"
                };

                public static IEnumerable<SettingDescriptor> AllSettings
                {
                    get
                    {
                        yield return $ext_supersafename$Enabled;
                        yield return $ext_supersafename$Password;
                    }
                }
            }

            public static IEnumerable<SettingDescriptor> AllSettings
            {
                get
                {
                    return General.AllSettings;
                }
            }
        }
    }
}
