using Moq;
using PostgresEF.Controllers.API;
using PostgresEF.Models.Entities;
using PostgresEF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PostgresEFTests
{
    public class CartControllerTests
    {
        private readonly CartController controller;
        private readonly Mock<IPaymentService> paymentServiceMock;
        private readonly Mock<ICartService> cartServiceMock;
        private readonly Mock<IShipmentService> shipmentServiceMock;
        private readonly Mock<ICheckoutDto> checkoutDtoMock;
        private readonly List<ICartItem> items;

        public CartControllerTests()
        {
            paymentServiceMock = new Mock<IPaymentService>();
            cartServiceMock = new Mock<ICartService>();
            shipmentServiceMock = new Mock<IShipmentService>();
            checkoutDtoMock = new Mock<ICheckoutDto>();

            var cartItemMock = new Mock<ICartItem>();
            cartItemMock.Setup(item => item.Price).Returns(10);

            items = new List<ICartItem>()
            {
                cartItemMock.Object,
            };

            cartServiceMock.Setup(c => c.Items()).Returns(items.AsEnumerable());

            controller = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object);
            
        }

        [Fact]
        public void Checkout_ShouldReturnCharged()
        {
            // arrange
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), checkoutDtoMock.Object.Card)).Returns(true);

            // act
            var result = controller.CheckOut(checkoutDtoMock.Object);

            // assert
            shipmentServiceMock.Verify(s => s.Ship(checkoutDtoMock.Object.AddressInfo, items.AsEnumerable()), Times.Once());

            Assert.Equal("charged", result);

        }

        [Fact]
        public void Checkout_ShouldReturnNotCharged()
        {
            // arrange
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), checkoutDtoMock.Object.Card)).Returns(() => false);

            // act
            var result = controller.CheckOut(checkoutDtoMock.Object);

            // assert
            shipmentServiceMock.Verify(s => s.Ship(checkoutDtoMock.Object.AddressInfo, items.AsEnumerable()), Times.Never());

            Assert.Equal("not charged", result);
        }
    }
}
