using Microsoft.AspNetCore.Mvc;
using PostgresEF.Models.Interfaces;

namespace PostgresEF.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IPaymentRepository _paymentService;
        private readonly IShipmentRepository _shipmentService;

        public CartController(
            ICartService cartService, 
            IPaymentRepository paymentService, 
            IShipmentRepository shipmentService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _shipmentService = shipmentService;
        }

        [HttpPost]
        [Route("[action]/{checkoutDto}")]
        public string CheckOut(ICheckoutDto checkoutDto)
        {
            var result = _paymentService.Charge(_cartService.Total(), checkoutDto.Card);
            if (result)
            {
                _shipmentService.Ship(checkoutDto.AddressInfo, _cartService.Items());
                return "charged";
            }
            else
            {
                return "not charged";
            }
        }
        
    }
}
