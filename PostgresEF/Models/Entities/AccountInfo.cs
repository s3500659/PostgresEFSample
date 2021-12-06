namespace PostgresEF.Models.Entities
{
    public class AccountInfo
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
