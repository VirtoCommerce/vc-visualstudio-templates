using VirtoCommerce.Domain.Order.Model;

namespace $safeprojectname$.Models.Order
{
    public class Invoice : OrderOperation
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

    }
}
