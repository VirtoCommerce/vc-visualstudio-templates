using System.Linq;
using $ext_safeprojectname$.Core.Models.Cart;
using $ext_safeprojectname$.Core.Models.Order;
using $ext_safeprojectname$.Data.Models.Cart;
using $ext_safeprojectname$.Data.Models.Order;
using VirtoCommerce.Platform.Core.Common;
using Xunit;

namespace $safeprojectname$
{
    using CartLineItemEx = Core.Models.Cart.LineItemEx;

    public class Test
    {
        public Test()
        {
        }

        [Theory]
        [InlineData(CartExType.Whishlist)]
        [InlineData(CartExType.Regular)]
        public void Convert_CartEx_DTOToEntity_EntityToDTO(CartExType input)
        {
            var model = new CartEx()
            {
                CartType = input
            };

            var pkMap = new PrimaryKeyResolvingMap();
            var entityForPatch = (CartExEntity)AbstractTypeFactory<CartExEntity>.TryCreateInstance().FromModel(model, pkMap);

            var entity = AbstractTypeFactory<CartExEntity>.TryCreateInstance();
            entityForPatch.Patch(entity);

            var modelResult = (CartEx)entity.ToModel(AbstractTypeFactory<CartEx>.TryCreateInstance());

            Assert.Equal(input.ToString(), entityForPatch.CartType);
            Assert.Equal(input.ToString(), entity.CartType);
            Assert.Equal(input, modelResult.CartType);
        }

        [Fact]
        public void Convert_LineItemEx_DTOToEntity_EntityToDTO()
        {
            const string outerId = "outer_id";

            var model = new CartLineItemEx()
            {
                OuterId = outerId
            };

            var pkMap = new PrimaryKeyResolvingMap();
            var entityForPatch = (LineItemExEntity)AbstractTypeFactory<LineItemExEntity>.TryCreateInstance().FromModel(model, pkMap);

            var entity = AbstractTypeFactory<LineItemExEntity>.TryCreateInstance();
            entityForPatch.Patch(entity);

            var modelResult = (CartLineItemEx)entity.ToModel(AbstractTypeFactory<CartLineItemEx>.TryCreateInstance());

            Assert.Equal(outerId, entityForPatch.OuterId);
            Assert.Equal(outerId, entity.OuterId);
            Assert.Equal(outerId, modelResult.OuterId);
        }

        [Fact]
        public void Convert_CustomerOrderEx_DTOToEntity_EntityToDTO()
        {
            const string field = "newField";

            var invoices = new Invoice[]
            {
                new Invoice() { CustomerId = "CustomerId1", CustomerName = "CustomerName1" },
                new Invoice() { CustomerId = "CustomerId2", CustomerName = "CustomerName2" },
            };

            var model = new CustomerOrderEx()
            {
                NewField = field,
                Invoices = invoices
            };

            var pkMap = new PrimaryKeyResolvingMap();
            var entityForPatch = (CustomerOrderExEntity)AbstractTypeFactory<CustomerOrderExEntity>.TryCreateInstance().FromModel(model, pkMap);

            var entity = AbstractTypeFactory<CustomerOrderExEntity>.TryCreateInstance();
            entityForPatch.Patch(entity);

            var modelResult = (CustomerOrderEx)entity.ToModel(AbstractTypeFactory<CustomerOrderEx>.TryCreateInstance());

            Assert.Equal(field, entityForPatch.NewField);
            Assert.Equal(field, entity.NewField);
            Assert.Equal(field, modelResult.NewField);

            Assert.Equal(invoices.Count(), entityForPatch.Invoices.Count);
            Assert.Equal(invoices.Count(), entity.Invoices.Count());
            Assert.Equal(invoices.Count(), modelResult.Invoices.Count);
        }

        [Fact]
        public void Patch_Invoice_Entity()
        {
            const string customerId = "customer_id";
            const string customerName = "customer_name";

            var entityForPatch = AbstractTypeFactory<InvoiceEntity>.TryCreateInstance();
            entityForPatch.CustomerId = customerId;
            entityForPatch.CustomerName = customerName;

            var entity = AbstractTypeFactory<InvoiceEntity>.TryCreateInstance();
            entityForPatch.Patch(entity);

            Assert.Equal(customerId, entity.CustomerId);
            Assert.Equal(customerName, entity.CustomerName);
        }
    }
}
