
using System;

namespace Classes_M3;

public class BankAccount
{
    private static int s_nextAccountNumber;

    // Static properties
    public static double InterestRate { get; private set; }
    public static double TransactionRate { get; private set; }
    public static double MaxTransactionFee { get; private set; }
    public static double OverdraftRate { get; private set; }
    public static double MaxOverdraftFee { get; private set; }

    public int AccountNumber { get; }
    public string CustomerId { get; }

    public double Balance { get; private set; } = 0;
    public string AccountType { get; set; } = "Checking";

    // Static constructor
    static BankAccount()
    {
        Random random = new Random();

        s_nextAccountNumber = random.Next(10000000, 20000000);

        InterestRate = 0.00;
        TransactionRate = 0.01;
        MaxTransactionFee = 10;
        OverdraftRate = 0.05;
        MaxOverdraftFee = 10;
    }

    // Constructor with optional parameters
    public BankAccount(
        string customerIdNumber,
        double balance = 200,
        string accountType = "Checking")
    {
        AccountNumber = s_nextAccountNumber++;
        CustomerId = customerIdNumber;
        Balance = balance;
        AccountType = accountType;
    }

    // Copy constructor
    public BankAccount(BankAccount existingAccount)
    {
        AccountNumber = s_nextAccountNumber++;
        CustomerId = existingAccount.CustomerId;
        Balance = existingAccount.Balance;
        AccountType = existingAccount.AccountType;
    }

    // Deposit
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    // Withdraw
    public bool Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }

    // Transfer
    public bool Transfer(BankAccount targetAccount, double amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            return true;
        }

        return false;
    }

    // Apply compound interest
    public void ApplyInterest(double years)
    {
        Balance += AccountCalculations.CalculateCompoundInterest(
            Balance, InterestRate, years);
    }

    // Issue cashier's check
    public bool IssueCashiersCheck(double amount)
    {
        if (amount > 0 &&
            Balance >= amount + MaxTransactionFee)
        {
            Balance -= amount;

            Balance -= AccountCalculations.CalculateTransactionFee(
                amount, TransactionRate, MaxTransactionFee);

            return true;
        }

        return false;
    }

    // Apply refund
    public void ApplyRefund(double refund)
    {
        if (refund > 0)
        {
            Balance += refund;
        }
    }

    // Display account information
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
    }
}
