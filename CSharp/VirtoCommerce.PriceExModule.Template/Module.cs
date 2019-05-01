using Microsoft.Practices.Unity;
using VirtoCommerce.Domain.Pricing.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using $projectname$.Model;
using $projectname$.Repositories;
using VirtoCommerce.PricingModule.Data.Model;
using VirtoCommerce.PricingModule.Data.Repositories;

namespace $safeprojectname$
{
    public class Module : ModuleBase
    {
        private const string _connectionStringName = "VirtoCommerce";
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        public override void SetupDatabase()
        {
            base.SetupDatabase();

            using (var db = new PriceExRepository(_connectionStringName, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<PriceExRepository, Migrations.Configuration>();
                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            _container.RegisterType<IPricingRepository>(new InjectionFactory(c => new PriceExRepository(_connectionStringName, _container.Resolve<AuditableInterceptor>(),
                new EntityPrimaryKeyGeneratorInterceptor())));
        }

        public override void PostInitialize()
        {
            base.Initialize();

            AbstractTypeFactory<Price>.OverrideType<Price, PriceEx>();
            AbstractTypeFactory<PriceEntity>.OverrideType<PriceEntity, PriceExEntity>();
        }
    }
}
