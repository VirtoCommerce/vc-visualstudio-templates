using System;
using VirtoCommerce.OrderModule.Data.Model;

namespace $safeprojectname$.Model.Order
{
    public class InvoiceEntity : OperationEntity
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }


        public CustomerOrderExEntity CustomerOrderEx { get; set; }
        public string CustomerOrderExId { get; set; }

        public override void Patch(OperationEntity operation)
        {
            base.Patch(operation);

            var target = operation as InvoiceEntity;
            if (target == null)
                throw new ArgumentException("operation");

            target.CustomerId = this.CustomerId;
            target.CustomerName = this.CustomerName;
        }
    }
}
