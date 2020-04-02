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
                public const string Create = "$ext_safeprojectname$:create";
                public const string Access = "$ext_safeprojectname$:access";
                public const string Read = "$ext_safeprojectname$:read";
                public const string Update = "$ext_safeprojectname$:update";
                public const string Delete = "$ext_safeprojectname$:delete";

                public static string[] AllPermissions = { Read, Create, Access, Update, Delete };
        }
        }
    
        public static class Settings
        {
            public static class General
            {
                public static SettingDescriptor $ext_safeprojectname$Enabled = new SettingDescriptor
                {
                    Name = "$ext_safeprojectname$.$ext_safeprojectname$Enabled",
                    GroupName = "$ext_safeprojectname|General",
                    ValueType = SettingValueType.Boolean,
                    DefaultValue = false
                };

                public static SettingDescriptor $ext_safeprojectname$Password = new SettingDescriptor
                {
                    Name = "$ext_safeprojectname$.$ext_safeprojectname$Password",
                    GroupName = "$ext_safeprojectname|Advanced",
                    ValueType = SettingValueType.SecureString,
                    DefaultValue = "qwerty"
                };

                public static IEnumerable<SettingDescriptor> AllSettings
                {
                    get
                    {
                        yield return $ext_safeprojectname$Enabled;
                        yield return $ext_safeprojectname$Password;
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
