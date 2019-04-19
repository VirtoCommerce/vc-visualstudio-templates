using System.Data.Entity;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using $projectname$.Model;
using VirtoCommerce.PricingModule.Data.Repositories;

namespace $projectname$.Repositories
{
    public class PriceExRepository : PricingRepositoryImpl
    {
        public PriceExRepository()
            : base()
        {
        }

        public PriceExRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, interceptors)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceExEntity>().HasKey(x => x.Id).Property(x => x.Id);
            modelBuilder.Entity<PriceExEntity>().ToTable("PriceEx");

            base.OnModelCreating(modelBuilder);
        }
    }
}