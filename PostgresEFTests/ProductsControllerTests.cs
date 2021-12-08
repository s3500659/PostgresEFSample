using Microsoft.AspNetCore.Mvc;
using Moq;
using PostgresEF.Controllers;
using PostgresEF.Interfaces;
using PostgresEF.Models;
using PostgresEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PostgresEFTests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductRepository> productRepoMock;

        public ProductsControllerTests()
        {
            productRepoMock = new Mock<IProductRepository>();
        }

        [Fact]
        public async void GetProducts_ShouldReturnAllProducts()
        {
            // arrange
            var itemMock = new Mock<IProduct>();
            itemMock.Setup(x => x.ID).Returns(It.IsAny<int>());

            var products = new List<IProduct>()
            {
                itemMock.Object,
            };

            productRepoMock.Setup(p => p.GetAll())
                .ReturnsAsync(products.AsEnumerable());
            
            // act
            var productsController = new ProductsController(productRepoMock.Object);

            var result = await productsController.GetProducts();

            var actual = (result.Result as OkObjectResult).Value;

            // assert
            productRepoMock.Verify(p => p.GetAll(), Times.Once);

            Assert.Equal(products, actual);
        }
    }
}
