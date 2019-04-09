using $ext_safeprojectname$.Core.Model;
using System.ComponentModel.DataAnnotations;
using VirtoCommerce.CartModule.Data.Model;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Platform.Core.Common;

namespace $safeprojectname$.Model
{
    public class CartExEntity : ShoppingCartEntity
    {
        [StringLength(64)]
        public string CartType { get; set; }

        public override ShoppingCart ToModel(ShoppingCart cart)
        {
            var result = base.ToModel(cart);

            var cartEx = (CartEx)result;
            cartEx.CartType = EnumUtility.SafeParse(CartType, CartExType.Regular);

            return cartEx;
        }

        public override ShoppingCartEntity FromModel(ShoppingCart cart, PrimaryKeyResolvingMap pkMap)
        {
            base.FromModel(cart, pkMap);

            var cartEx = (CartEx)cart;
            CartType = cartEx.CartType.ToString();

            return this;
        }

        public override void Patch(ShoppingCartEntity target)
        {
            base.Patch(target);

            var cart2Entity = (CartExEntity)target;
            cart2Entity.CartType = CartType;
        }
    }
}
