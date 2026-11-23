
using System;

namespace Classes_M2;

public static class BankCustomerExtensions
{
    // Check if customer ID is valid
    public static bool IsValidCustomerId(this BankCustomer customer)
    {
        return customer.CustomerId.Length == 10;
    }

    // Greet customer
    public static string GreetCustomer(this BankCustomer customer)
    {
        return $"Hello, {customer.ReturnFullName()}!";
    }
}

public static class BankAccountExtensions
{
    // Check if account is overdrawn
    public static bool IsOverdrawn(this BankAccount account)
    {
        return account.Balance < 0;
    }

    // Check if an amount can be withdrawn
    public static bool CanWithdraw(this BankAccount account, double amount)
    {
        return account.Balance >= amount;
    }
}
