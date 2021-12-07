namespace PostgresEF.Models.Interfaces
{
    public interface ICheckoutDto
    {
        public ICard Card { get; set; }
        public IAddressInfo AddressInfo { get; set; }
    }
}
