using System.Collections.Generic;
using VirtoCommerce.Domain.Customer.Model;

namespace $safeprojectname$.Models
{
    public class Supplier : Member
    {
        public Supplier()
        {
            Reviews = new List<SupplierReview>();
        }

        public string ContractNumber { get; set; }
        public ICollection<SupplierReview> Reviews { get; set; }
    }
}
