namespace PostgresEF.Models.Interfaces
{
    public interface ICartItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}