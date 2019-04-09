using System.Collections.Generic;
using VirtoCommerce.Domain.Order.Model;

namespace $safeprojectname$.Model
{
    public class CustomerOrderEx : CustomerOrder
    {
        public CustomerOrderEx()
        {
            Invoices = new List<Invoice>();
        }

        public string NewField { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
