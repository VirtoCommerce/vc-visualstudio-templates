using System.Data.Entity;
using System.Linq;
using $safeprojectname$.Models;
using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace $safeprojectname$.Repositories
{
    public class SupplierRepository : CustomerRepositoryImpl
    {
        public SupplierRepository()
        {
        }

        public SupplierRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, interceptors)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierDataEntity>().ToTable("MemberSupplier").HasKey(x => x.Id)
                .Property(x => x.Id);

            modelBuilder.Entity<SupplierReviewDataEntity>().ToTable("MemberSupplierReview").HasKey(x => x.Id)
                .Property(x => x.Id);
            modelBuilder.Entity<SupplierReviewDataEntity>().HasRequired(m => m.Supplier)
                                                 .WithMany(m => m.Reviews).HasForeignKey(m => m.SupplierId)
                                                 .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<SupplierDataEntity> Suppliers
        {
            get { return GetAsQueryable<SupplierDataEntity>(); }
        }

        public IQueryable<SupplierReviewDataEntity> SupplierReviews
        {
            get { return GetAsQueryable<SupplierReviewDataEntity>(); }
        }

        public override MemberDataEntity[] GetMembersByIds(string[] ids, string responseGroup = null, string[] memberTypes = null)
        {
            var retVal = base.GetMembersByIds(ids, responseGroup, memberTypes);
            var reviews = SupplierReviews.Where(x => ids.Contains(x.SupplierId)).ToArray();
            return retVal;
        }
    }
}
