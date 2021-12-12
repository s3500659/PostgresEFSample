namespace PostgresEF.Models
{
    public interface IEmail
    {
        int Id { get; set; }
        string EmailAddress { get; set; }
        int CustomerId { get; set; }
        Customer Customer { get; set; }
    }
}