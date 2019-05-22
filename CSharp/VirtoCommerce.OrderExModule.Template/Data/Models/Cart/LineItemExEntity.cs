using System.ComponentModel.DataAnnotations;
using $ext_safeprojectname$.Core.Models.Cart;
using VirtoCommerce.CartModule.Data.Model;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Platform.Core.Common;

namespace $safeprojectname$.Models.Cart
{
    public class LineItemExEntity : LineItemEntity
    {
        [StringLength(128)]
        public string OuterId { get; set; }

        public override LineItem ToModel(LineItem lineItem)
        {
            var result = base.ToModel(lineItem);

            var lineItemEx = (LineItemEx)result;
            lineItemEx.OuterId = OuterId;

            return lineItemEx;
        }

        public override LineItemEntity FromModel(LineItem lineItem, PrimaryKeyResolvingMap pkMap)
        {
            base.FromModel(lineItem, pkMap);

            var lineItemEx = (LineItemEx)lineItem;
            OuterId = lineItemEx.OuterId;

            return this;
        }

        public override void Patch(LineItemEntity target)
        {
            base.Patch(target);

            var lineItem2Entity = (LineItemExEntity)target;
            lineItem2Entity.OuterId = OuterId;
        }
    }
}
