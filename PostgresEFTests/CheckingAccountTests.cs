using PostgresEF.Models;
using PostgresEF.Models.Entities;
using System;
using Xunit;

namespace PostgresEFTests
{
    public class CheckingAccountTests
    {
        [Fact]
        public void Withdraw_ValidAmount_ChangesBalance()
        {
            // Arrange
            var currentBalance = 10;
            var withdrawal = 1;
            var expected = 9;
            var email = new Email("vinh@gmail.com");
            var customer = new Customer("Vinh", "Tran", email);
            var account = new CheckingAccount(customer, currentBalance);

            // Act
            account.Withdraw(withdrawal);

            // Assert
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void Withdraw_AmountMoreThanBalance_Throws()
        {
            // Arrange
            var email = new Email("vinh@gmail.com");
            var customer = new Customer("Vinh", "Tran", email);
            var account = new CheckingAccount(customer, 0);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(20));
        }

        [Fact]
        public void Deposit_ValidAmount_ShouldIncreaseBalance()
        {
            var currentBalance = 10;
            var deposit = 10;
            var expected = 20;
            var email = new Email("vinh@gmail.com");
            var customer = new Customer("Vinh", "Tran", email);
            var account = new CheckingAccount(customer, currentBalance);

            account.Deposit(deposit);

            Assert.Equal(expected, account.GetBalance());
            
        }

        [Fact]
        public void Deposit_InvalidAmount_ShouldThrowException()
        {
            var deposit = -1;
            var email = new Email("vinh@gmail.com");
            var customer = new Customer("Vinh", "Tran", email);
            var account = new CheckingAccount(customer, 0);

            Assert.Throws<ArgumentException>(() => account.Deposit(deposit));
        }
    }
}
