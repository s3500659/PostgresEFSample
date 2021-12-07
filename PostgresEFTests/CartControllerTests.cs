using Moq;
using PostgresEF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresEFTests
{
    public class CartControllerTests
    {
        public IPaymentService PaymentServiceMock { get; set; }
        public CartControllerTests()
        {
            //PaymentServiceMock = new Mock<IPaymentService>();
        }
    }
}
