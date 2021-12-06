using PostgresEF.Models.Interfaces;
using System;

namespace PostgresEF.Models.Entities
{
    public class CheckingAccount : IAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(nameof(amount), "Invalid deposit amount");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new ArgumentException(nameof(amount), "Withdraw exceeds balance");
            }
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        
    }
}
