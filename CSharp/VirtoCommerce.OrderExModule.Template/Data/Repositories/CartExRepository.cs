using System.Data.Entity;
using $safeprojectname$.Models.Cart;
using VirtoCommerce.CartModule.Data.Repositories;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace $safeprojectname$.Repositories
{
    public class CartExRepository : CartRepositoryImpl
    {
        public CartExRepository()
            : base()
        {
        }

        public CartExRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, interceptors)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartExEntity>().ToTable("CartEx").HasKey(x => x.Id).Property(x => x.Id);
            modelBuilder.Entity<LineItemExEntity>().ToTable("CartLineItemEx").HasKey(x => x.Id).Property(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
