namespace $safeprojectname$.Model
{
    using CartLineItem = VirtoCommerce.Domain.Cart.Model.LineItem;
    using OrderLineItem = VirtoCommerce.Domain.Order.Model.LineItem;

    public class CartLineItemEx : CartLineItem
    {
        public string OuterId { get; set; }
    }

    public class OrderLineItemEx : OrderLineItem
    {
        public string OuterId { get; set; }
    }
}
