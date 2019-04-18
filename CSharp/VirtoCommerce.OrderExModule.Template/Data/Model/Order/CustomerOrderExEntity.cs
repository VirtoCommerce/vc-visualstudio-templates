using $ext_safeprojectname$.Core.Model.Order;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.OrderModule.Data.Model;
using VirtoCommerce.Platform.Core.Common;

namespace $safeprojectname$.Model.Order
{
    public class CustomerOrderExEntity : CustomerOrderEntity
    {
        public CustomerOrderExEntity()
        {
            Invoices = new NullCollection<InvoiceEntity>();
        }

        [StringLength(128)]
        public string NewField { get; set; }

        public virtual ObservableCollection<InvoiceEntity> Invoices { get; set; }


        public override OrderOperation ToModel(OrderOperation operation)
        {
            var orderEx = operation as CustomerOrderEx;

            if (orderEx != null)
                orderEx.Invoices = this.Invoices.Select(x => x.ToModel(new Invoice())).OfType<Invoice>().ToList();

            base.ToModel(operation);

            return operation;
        }

        public override OperationEntity FromModel(OrderOperation operation, PrimaryKeyResolvingMap pkMap)
        {
            var orderEx = operation as CustomerOrderEx;
            if (orderEx != null && orderEx.Invoices != null)
                Invoices = new ObservableCollection<InvoiceEntity>(orderEx.Invoices.Select(x => new InvoiceEntity().FromModel(x, pkMap)).OfType<InvoiceEntity>());

            base.FromModel(operation, pkMap);

            return this;
        }

        public override void Patch(OperationEntity operation)
        {
            var target = operation as CustomerOrderExEntity;
            if (target != null)
            {
                target.NewField = this.NewField;
                if (!Invoices.IsNullCollection())
                    Invoices.Patch(target.Invoices, (sourceInvoice, targetInvoice) => sourceInvoice.Patch(targetInvoice));
            }

            base.Patch(operation);
        }
    }
}
