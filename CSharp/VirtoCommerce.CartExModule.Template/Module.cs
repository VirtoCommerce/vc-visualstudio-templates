using Microsoft.Practices.Unity;
using $projectname$.Model;
using $projectname$.Repositories;
using VirtoCommerce.CartModule.Data.Model;
using VirtoCommerce.CartModule.Data.Repositories;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

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

            using (var db = new CartExRepository(_connectionStringName, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<CartExRepository, Migrations.Configuration>();
                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            _container.RegisterType<ICartRepository>(new InjectionFactory(c => new CartExRepository(_connectionStringName, _container.Resolve<AuditableInterceptor>(), new EntityPrimaryKeyGeneratorInterceptor())));
        }

        public override void PostInitialize()
        {
            base.PostInitialize();

            AbstractTypeFactory<ShoppingCart>.OverrideType<ShoppingCart, CartEx>();
            AbstractTypeFactory<ShoppingCartEntity>.OverrideType<ShoppingCartEntity, CartExEntity>();
            AbstractTypeFactory<LineItem>.OverrideType<LineItem, LineItemEx>();
            AbstractTypeFactory<LineItemEntity>.OverrideType<LineItemEntity, LineItemExEntity>();
        }
    }
}
