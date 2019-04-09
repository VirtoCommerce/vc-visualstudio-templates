using $ext_safeprojectname$.Core.Model;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.OrderModule.Data.Model;
using VirtoCommerce.Platform.Core.Common;

namespace $safeprojectname$.Model
{
    public class LineItemExEntity : LineItemEntity
    {
        [StringLength(64)]
        public string OuterId { get; set; }

        public override LineItem ToModel(LineItem lineItem)
        {
            var result = base.ToModel(lineItem);

            var lineItemEx = (OrderLineItemEx)result;
            lineItemEx.OuterId = OuterId;

            return lineItemEx;
        }

        public override LineItemEntity FromModel(LineItem lineItem, PrimaryKeyResolvingMap pkMap)
        {
            base.FromModel(lineItem, pkMap);

            var lineItemEx = (OrderLineItemEx)lineItem;
            OuterId = lineItemEx.OuterId;

            return this;
        }

        public override void Patch(LineItemEntity target)
        {
            base.Patch(target);

            var lineItemExEntity = (LineItemExEntity)target;
            lineItemExEntity.OuterId = OuterId;
        }
    }
}
