using VirtoCommerce.Domain.Order.Model;

namespace $safeprojectname$.Model
{
    public class Invoice : OrderOperation
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

    }
}
