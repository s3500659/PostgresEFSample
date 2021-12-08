namespace PostgresEF.Models.Interfaces
{
    public interface IPaymentService
    {
        bool Charge(double total, ICard card);
    }
}