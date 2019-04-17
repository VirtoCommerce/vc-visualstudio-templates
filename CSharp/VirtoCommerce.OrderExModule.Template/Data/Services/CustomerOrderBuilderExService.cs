using $ext_safeprojectname$.Core.Model.Order;
using VirtoCommerce.Domain.Order.Services;
using VirtoCommerce.OrderModule.Data.Services;

namespace $safeprojectname$.Services
{
    using CartLineItem = VirtoCommerce.Domain.Cart.Model.LineItem;
    using OrderLineItem = VirtoCommerce.Domain.Order.Model.LineItem;

    public class CustomerOrderBuilderExService : CustomerOrderBuilderImpl
    {
        public CustomerOrderBuilderExService(ICustomerOrderService customerOrderService)
            : base(customerOrderService)
        {
        }

        protected override OrderLineItem ToOrderModel(CartLineItem lineItem)
        {
            var result = base.ToOrderModel(lineItem) as LineItemEx;

            // Next lines just copy OuterId from cart LineItemEx to order LineItemEx
            var cartLineItemEx = lineItem as Core.Model.Cart.LineItemEx;
            if (cartLineItemEx != null)
            {
                result.OuterId = cartLineItemEx.OuterId;
            }
            return result;
        }
    }
}
