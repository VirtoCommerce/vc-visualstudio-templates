using $safeprojectname$.Model;
using System.Data.Entity;
using System.Linq;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.OrderModule.Data.Model;
using VirtoCommerce.OrderModule.Data.Repositories;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace $safeprojectname$.Repositories
{
    public class OrderExRepository : OrderRepositoryImpl
    {
        public OrderExRepository()
            : base()
        {
        }

        public OrderExRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, interceptors)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region CustomerOrderEx
            modelBuilder.Entity<CustomerOrderExEntity>().HasKey(x => x.Id)
                .Property(x => x.Id);
            modelBuilder.Entity<CustomerOrderExEntity>().ToTable("CustomerOrderEx");
            #endregion

            #region OrderInvoice
            modelBuilder.Entity<InvoiceEntity>().HasKey(x => x.Id)
            .Property(x => x.Id);
            modelBuilder.Entity<InvoiceEntity>().ToTable("OrderInvoice");

            modelBuilder.Entity<InvoiceEntity>().HasRequired(m => m.CustomerOrderEx)
                                                 .WithMany(m => m.Invoices).HasForeignKey(m => m.CustomerOrderExId)
                                                 .WillCascadeOnDelete(true);
            #endregion

            base.OnModelCreating(modelBuilder);
        }


        public IQueryable<CustomerOrderExEntity> CustomerOrdersEx
        {
            get { return GetAsQueryable<CustomerOrderExEntity>(); }
        }

        public IQueryable<InvoiceEntity> Invoices
        {
            get { return GetAsQueryable<InvoiceEntity>(); }
        }

        public override CustomerOrderEntity[] GetCustomerOrdersByIds(string[] ids, CustomerOrderResponseGroup responseGroup)
        {
            var retVal = base.GetCustomerOrdersByIds(ids, responseGroup);
            return retVal;
        }
    }
}
