using $safeprojectname$.Model.Cart;
using System.Data.Entity;
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
            modelBuilder.Entity<CartExEntity>().HasKey(x => x.Id).Property(x => x.Id);
            modelBuilder.Entity<CartExEntity>().ToTable("CartEx");

            modelBuilder.Entity<LineItemExEntity>().HasKey(x => x.Id).Property(x => x.Id);
            modelBuilder.Entity<LineItemExEntity>().ToTable("CartLineItemEx");

            base.OnModelCreating(modelBuilder);
        }
    }
}
