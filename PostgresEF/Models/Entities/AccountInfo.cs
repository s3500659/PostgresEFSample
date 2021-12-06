namespace PostgresEF.Models.Entities
{
    public class AccountInfo
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
