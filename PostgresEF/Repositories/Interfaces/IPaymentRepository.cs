namespace PostgresEF.Models.Interfaces
{
    public interface IPaymentRepository
    {
        bool Charge(double total, ICard card);
    }
}