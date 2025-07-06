using FastTechFoods.ProductsManagerService.Domain.Entities;
using FastTechFoods.ProductsManagerService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTechFoods.ProductsManagerService.Tests.Domain
{
    public class ProductTests
    {
        [Fact]
        public void Should_Create_Product_With_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Test Product";
            var productType = ProductTypeEnum.Drink;
            var price = 10.99m;
            var description = "A test product description";
            var availability = AvailabilityStatusEnum.Available;

            // Act
            var product = new Product(id, name, productType, price, description, availability);

            // Assert
            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(productType, product.ProductType);
            Assert.Equal(price, product.Price);
            Assert.Equal(description, product.Description);
            Assert.Equal(availability, product.Availability);
        }

        [Fact]
        public void Should_Throw_Exception_When_Name_Is_Empty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = string.Empty;
            var productType = ProductTypeEnum.Drink;
            var price = 10.99m;
            var description = "A test product description";
            var availability = AvailabilityStatusEnum.Available;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                new Product(id, name, productType, price, description, availability));

            Assert.Equal("Product name cannot be empty. (Parameter 'name')", exception.Message);
        }

        [Fact]
        public void Should_Update_Product_Details()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Old Name", ProductTypeEnum.Drink, 10.99m, "Old Description", AvailabilityStatusEnum.Available);

            var newName = "New Name";
            var newPrice = 15.99m;
            var newDescription = "New Description";

            // Act
            product.UpdateDetails(newName, newPrice, newDescription);

            // Assert
            Assert.Equal(newName, product.Name);
            Assert.Equal(newPrice, product.Price);
            Assert.Equal(newDescription, product.Description);
            Assert.Equal(ProductTypeEnum.Drink, product.ProductType); 
            Assert.Equal(AvailabilityStatusEnum.Available, product.Availability);
        }


    }
}
