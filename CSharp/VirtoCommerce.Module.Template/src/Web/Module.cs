using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Settings;
using $ext_safeprojectname$.Core;
using $ext_safeprojectname$.Data.Repositories;

namespace $safeprojectname$
{
    public class Module : IModule
    {
        public ManifestModuleInfo ModuleInfo { get; set; }

        public void Initialize(IServiceCollection serviceCollection)
        {
            // initialize DB
            serviceCollection.AddDbContext<$ext_supersafename$DbContext> ((provider, options) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                options.UseSqlServer(configuration.GetConnectionString(ModuleInfo.Id) ?? configuration.GetConnectionString("VirtoCommerce"));
            });

        // TODO:
        // serviceCollection.AddTransient<I$ext_supersafename$Repository, $ext_supersafename$Repository>();
        // serviceCollection.AddTransient<Func<I$ext_supersafename$Repository>>(provider => () => provider.CreateScope().ServiceProvider.GetRequiredService<I$ext_supersafename$Repository>());
    }

        public void PostInitialize(IApplicationBuilder appBuilder)
        {
            // register settings
            var settingsRegistrar = appBuilder.ApplicationServices.GetRequiredService<ISettingsRegistrar>();
            settingsRegistrar.RegisterSettings(ModuleConstants.Settings.AllSettings, ModuleInfo.Id);

            // register permissions
            var permissionsProvider = appBuilder.ApplicationServices.GetRequiredService<IPermissionsRegistrar>();
            permissionsProvider.RegisterPermissions(ModuleConstants.Security.Permissions.AllPermissions.Select(x =>
                new Permission()
                {
                    GroupName = "$ext_supersafename$",
                    ModuleId = ModuleInfo.Id,
                    Name = x
                }).ToArray());

            // ensure that all pending migrations are applied
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<$ext_supersafename$DbContext>())
                {
                    dbContext.Database.EnsureCreated();
                    dbContext.Database.Migrate();
                }
            }
        }

        public void Uninstall()
        {
            // do nothing in here
        }
    }
}
