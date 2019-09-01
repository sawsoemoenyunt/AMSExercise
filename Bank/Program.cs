using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankAccount
    {
        // Private variables for storing the account balance and interest rate
        // ...
        private double balance, interestRate;

        /// <summary>
        /// Creates a new bank account with no starting balance and the default
        /// interest rate.
        /// </summary>
        public BankAccount()
        {
            // ...
            this.balance = 0.0;
            this.interestRate = 9.8; //9.8 percentage
        }

        /// <summary>
        /// Creates a new bank account with a starting balance and the default
        /// interest rate.
        /// </summary>
        /// <param name="startingBalance">The starting balance</param>
        public BankAccount(double startingBalance)
        {
            // ...
            this.balance = startingBalance;
            this.interestRate = 9.8;
        }

        /// <summary>
        /// Creates a new bank account with a starting balance and interest
        /// rate.
        /// </summary>
        /// <param name="startingBalance">The starting balance</param>
        /// <param name="interestRate">The interest rate (in percentage)</param>
        public BankAccount(double startingBalance, double interestRate)
        {
            // ...
            this.balance = startingBalance;
            this.interestRate = interestRate;
        }

        /// <summary>
        /// Reduce the balance of the bank account by 'amount' and return true.
        /// If there are insufficient funds in the account, the balance does not
        /// change and false is returned instead. 
        /// </summary>
        /// <param name="amount">The amount of money to deduct from the account
        /// </param>
        /// <returns>True if funds were deducted from the account, and false
        /// otherwise</returns>
        public bool Withdraw(double amount)
        {
            // ...
            if (this.balance >= amount)
            {
                this.balance = this.balance - amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Increase the balance of the account by 'amount'
        /// </summary>
        /// <param name="amount">The amount to increase the balance by</param>
        public void Deposit(double amount)
        {
            // ...
            this.balance += amount;
        }

        /// <summary>
        /// Returns the total balance currently in the account.
        /// </summary>
        /// <returns>The total balance currently in the account</returns>
        public double QueryBalance()
        {
            // ...
            return this.balance;
        }

        /// <summary>
        /// Sets the account's interest rate to the rate provided
        /// </summary>
        /// <param name="interestRate">The interest rate for this account (%)
        /// </param>
        public void SetInterestRate(double interestRate)
        {
            // ...
            this.interestRate = interestRate;
        }

        /// <summary>
        /// Returns the account's interest rate
        /// </summary>
        /// <returns>The percentage interest rate of this account</returns>
        public double GetInterestRate()
        {
            // ...
            return this.interestRate;
        }

        /// <summary>
        /// Calculates the interest on the current account balance and adds it
        /// to the account
        /// </summary>
        public void AddInterest()
        {
            // ...
            this.balance = this.balance + (this.balance * (this.interestRate / 100));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount(0, 5);
            myAccount.Deposit(1000);
            myAccount.AddInterest();
            Console.WriteLine("My current bank balance is $ {0:0.00}\n",
              myAccount.QueryBalance());

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}