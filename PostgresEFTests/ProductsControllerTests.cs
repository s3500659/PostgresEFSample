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
        private readonly ProductsController productsController;
        private readonly IEnumerable<IProduct> products;

        public ProductsControllerTests()
        {
            productRepoMock = new Mock<IProductRepository>();

            var itemMock = new Mock<IProduct>();
            itemMock.Setup(x => x.ID).Returns(It.IsAny<int>());

            products = new List<IProduct>()
            {
                itemMock.Object,
            };

            productRepoMock.Setup(p => p.GetAll())
                .ReturnsAsync(products.AsEnumerable());

            productsController = new ProductsController(productRepoMock.Object);
        }

        [Fact]
        public async void GetProducts_ShouldReturnAllProducts()
        {

            var result = await productsController.GetProducts();

            productRepoMock.Verify(p => p.GetAll(), Times.Once);

            Assert.Equal(products, result);

            
        }
    }
}
