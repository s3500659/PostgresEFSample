namespace PostgresEF.Models.Interfaces
{
    public interface IAccount
    {
        public void Deposit(decimal amount);
        public void Withdraw(decimal amount);
        public decimal GetBalance();

    }
}
