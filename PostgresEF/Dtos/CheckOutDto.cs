using PostgresEF.Models.Interfaces;

namespace PostgresEF.Dtos
{
    public class CheckOutDto : ICheckoutDto
    {
        public ICard Card { get; set; }
        public IAddressInfo AddressInfo { get; set; }
    }
}
