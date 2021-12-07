using Microsoft.AspNetCore.Mvc;
using PostgresEF.Dtos;
using PostgresEF.Models.Interfaces;

namespace PostgresEF.Controllers.API
{
    [ApiController]
    [Route("[controller]")]
    public class CartController
    {
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IShipmentService _shipmentService;

        public CartController(
            ICartService cartService, 
            IPaymentService paymentService, 
            IShipmentService shipmentService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _shipmentService = shipmentService;
        }

        [HttpPost]
        public string CheckOut(CheckOutDto checkOutDto)
        {
            var result = _paymentService.Charge(_cartService.Total(), checkOutDto.Card);
            if (result)
            {
                _shipmentService.Ship(checkOutDto.AddressInfo, _cartService.Items());
                return "charged";
            }
            else
            {
                return "not charged";
            }
        }
        
    }
}
