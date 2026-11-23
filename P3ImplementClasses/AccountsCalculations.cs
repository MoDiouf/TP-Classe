
using System;

namespace Classes_M3;

public static class AccountCalculations
{
    // Calculate compound interest
    public static double CalculateCompoundInterest(
        double principal,
        double annualRate,
        double years)
    {
        return principal * Math.Pow(1 + annualRate, years) - principal;
    }

    // Validate account number
    public static bool ValidateAccountNumber(int accountNumber)
    {
        return accountNumber.ToString().Length == 8;
    }

    // Calculate transaction fee
    public static double CalculateTransactionFee(
        double amount,
        double transactionRate,
        double maxTransactionFee)
    {
        double fee = amount * transactionRate;

        return Math.Min(fee, maxTransactionFee);
    }

    // Calculate overdraft fee
    public static double CalculateOverdraftFee(
        double amountOverdrawn,
        double overdraftRate,
        double maxOverdraftFee)
    {
        double fee = amountOverdrawn * overdraftRate;

        return Math.Min(fee, maxOverdraftFee);
    }

    // Return foreign currency
    public static double ReturnForeignCurrency(
        double amount,
        double exchangeRate)
    {
        return amount * exchangeRate;
    }
}
