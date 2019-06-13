using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using $ext_safeprojectname$.Core.Models;
using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Platform.Core.Common;

namespace $safeprojectname$.Models
{
    /// <summary>
    /// Represent persistent member type
    /// </summary>
    public class SupplierDataEntity : MemberDataEntity
    {
        public SupplierDataEntity()
        {
            Reviews = new NullCollection<SupplierReviewDataEntity>();
        }

        [StringLength(128)]
        public string ContractNumber { get; set; }

        public ObservableCollection<SupplierReviewDataEntity> Reviews { get; set; }

        /// <summary>
        /// This method used to convert domain Member type instance to data model
        /// </summary>
        public override MemberDataEntity FromModel(Member member, PrimaryKeyResolvingMap pkMap)
        {
            // Here you can write code for custom mapping.
            // Member properties will be mapped in base method implementation by using value injection
            var retVal = base.FromModel(member, pkMap) as SupplierDataEntity;
            var supplier = member as Supplier;

            if (supplier != null && !supplier.Reviews.IsNullOrEmpty())
            {
                retVal.Reviews = new ObservableCollection<SupplierReviewDataEntity>();
                foreach (var review in supplier.Reviews)
                {
                    var reviewDataEntity = new SupplierReviewDataEntity();
                    pkMap.AddPair(review, reviewDataEntity);
                    retVal.Reviews.Add(reviewDataEntity.FromModel(review));
                }
            }

            return retVal;
        }
        
        /// <summary>
        /// This method used to convert data type instance to domain model
        /// </summary>
        public override Member ToModel(Member member)
        {
            // Here you can write code for custom mapping.
            // Member properties will be mapped in base method implementation by using value injection
            var retVal = base.ToModel(member) as Supplier;

            if (retVal != null)
                retVal.Reviews = Reviews.OrderBy(x => x.Id).Select(x => x.ToModel(AbstractTypeFactory<SupplierReview>.TryCreateInstance())).ToList();

            return retVal;
        }
        
        /// <summary>
        /// This method used to apply changes form other member type instance 
        /// </summary>
        public override void Patch(MemberDataEntity target)
        {
            base.Patch(target);

            var supplierDataEntity = target as SupplierDataEntity;

            if (supplierDataEntity != null)
            {
                supplierDataEntity.ContractNumber = ContractNumber;

                if (!Reviews.IsNullCollection())
                    Reviews.Patch(supplierDataEntity.Reviews, (sourceReview, targetReview) => sourceReview.Patch(targetReview));
            }
        }
    }
}
