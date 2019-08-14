using System;
using System.Globalization;
using account_exceptions.Entities;
using account_exceptions.Entities.Exceptions;

namespace account_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data:");
                //
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                //
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                //
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                //
                Console.Write("Withdrawal limit: ");
                double withdrawalLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                //
                Account acc = new Account(number, holder, balance, withdrawalLimit);
                //
                Console.Write("Enter amount to withdraw: ");
                double toWithdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                acc.Withdraw(toWithdraw);

                Console.Write("New balance: " + acc.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch(DomainException e)
            {
                Console.WriteLine("Withdrawing error: " + e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
