using $ext_safeprojectname$.Core.Models;
using $ext_safeprojectname$.Data.Models;
using VirtoCommerce.Platform.Core.Common;
using Xunit;

namespace $safeprojectname$
{
    public class Test
    {
        public Test()
        {
        }

        [Fact]
        public void Convert_Supplier_DTOToEntity_EntityToDTO()
        {
            const string contactNumber = "+(358) 000-000000";

            var reviews = new SupplierReview[]
            {
                new SupplierReview() { Review = "Test review text 1" },
                new SupplierReview() { Review = "Test review text 2" }
            };

            var model = new Supplier()
            {
                ContractNumber = contactNumber,
                Reviews = reviews
            };

            var pkMap = new PrimaryKeyResolvingMap();
            var entityForPatch = (SupplierDataEntity)AbstractTypeFactory<SupplierDataEntity>.TryCreateInstance().FromModel(model, pkMap);

            var entity = AbstractTypeFactory<SupplierDataEntity>.TryCreateInstance();
            entityForPatch.Patch(entity);

            var modelResult = (Supplier)entity.ToModel(AbstractTypeFactory<Supplier>.TryCreateInstance());

            Assert.Equal(contactNumber, entityForPatch.ContractNumber);
            Assert.Equal(contactNumber, entity.ContractNumber);
            Assert.Equal(contactNumber, modelResult.ContractNumber);

            Assert.Equal(reviews.Length, entityForPatch.Reviews.Count);
            Assert.Equal(reviews.Length, entity.Reviews.Count);
            Assert.Equal(reviews.Length, modelResult.Reviews.Count);
        }
    }
}
