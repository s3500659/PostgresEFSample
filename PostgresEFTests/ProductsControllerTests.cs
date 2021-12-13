using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PostgresEF.Controllers;
using PostgresEF.Dtos;
using PostgresEF.Factory.Interfaces;
using PostgresEF.Interfaces;
using PostgresEF.Profiles;
using PostgresEF.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PostgresEFTests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductRepository> productRepoMock;
        private readonly Mock<IProductFactory> productFactory;

        public ProductsControllerTests()
        {
            productRepoMock = new Mock<IProductRepository>();
            productFactory = new Mock<IProductFactory>();
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
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductsProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var productsController = new ProductsController(
                productRepoMock.Object, productFactory.Object, mapper);


            var result = await productsController.GetProducts();

            var actual = (result.Result as OkObjectResult).Value as IEnumerable<ReadProductDto>;

            // assert
            productRepoMock.Verify(p => p.GetAll(), Times.Once);

            var expected = actual.FirstOrDefault().Name;
            var actual2 = products.FirstOrDefault().Name;

            Assert.Equal(expected, actual2);
        }
    }
}
