using System.ComponentModel.DataAnnotations;
using $ext_safeprojectname$.Core.Models;
using Omu.ValueInjecter;
using VirtoCommerce.Platform.Core.Common;

namespace $safeprojectname$.Models
{
    public class SupplierReviewDataEntity : AuditableEntity
    {
        [StringLength(2048)]
        public string Review { get; set; }

        [StringLength(128)]
        public string SupplierId { get; set; }

        public virtual SupplierDataEntity Supplier { get; set; }

        public virtual SupplierReview ToModel(SupplierReview review)
        {
            review.InjectFrom(this);
            return review;

        }

        public virtual SupplierReviewDataEntity FromModel(SupplierReview review)
        {
            this.InjectFrom(review);
            return this;
        }

        public virtual void Patch(SupplierReviewDataEntity target)
        {
            target.Review = this.Review;
        }
    }
}
