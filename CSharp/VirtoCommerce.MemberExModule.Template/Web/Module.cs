using System;
using $ext_safeprojectname$.Core.Models;
using $ext_safeprojectname$.Data.Models;
using $ext_safeprojectname$.Data.Repositories;
using $ext_safeprojectname$.Data.Services;
using Microsoft.Practices.Unity;
using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace $safeprojectname$
{
    public class Module : ModuleBase
    {
        private readonly string _connectionString = ConfigurationHelper.GetConnectionStringValue("VirtoCommerce");
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        public override void SetupDatabase()
        {
            using (var db = new SupplierRepository(_connectionString, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<SupplierRepository, Data.Migrations.Configuration>();
                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
            Func<SupplierRepository> supplierRepositoryFactory = () => new SupplierRepository(_connectionString, new EntityPrimaryKeyGeneratorInterceptor(), _container.Resolve<AuditableInterceptor>());

            _container.RegisterInstance<Func<ICustomerRepository>>(supplierRepositoryFactory);
            _container.RegisterInstance<Func<IMemberRepository>>(supplierRepositoryFactory);

            _container.RegisterType<IMemberService, SupplierMemberService>();
            _container.RegisterType<IMemberSearchService, SupplierMemberService>();

            base.Initialize();
        }

        public override void PostInitialize()
        {
            AbstractTypeFactory<Member>.RegisterType<Supplier>().MapToType<SupplierDataEntity>();
            AbstractTypeFactory<MemberDataEntity>.RegisterType<SupplierDataEntity>();

            base.PostInitialize();
        }
    }
}
