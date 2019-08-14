using System;
using account_exceptions.Entities.Exceptions;

namespace account_exceptions.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawalLimit { get; set; }
        public Account()
        {
        }
        public Account(int number, string holder, double balance, double withdrawalLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawalLimit = withdrawalLimit;
        }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            if(amount > WithdrawalLimit)
            {
                throw new DomainException($"The amount exceeds withdrawal limit. Your withdrawal limit is R${WithdrawalLimit}");
            }
            if(amount > Balance)
            {
                throw new DomainException($"Not enough balance. You account balance is: R${Balance}");
            }
            Balance -= amount;
        }
    }
}