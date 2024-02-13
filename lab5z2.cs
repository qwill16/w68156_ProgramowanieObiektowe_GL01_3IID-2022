using System;
using System.Collections.Generic;

// Abstrakcyjna klasa Transaction
public abstract class Transaction
{
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    public abstract void ProcessTransaction();
}

// Klasa IncomeTransaction dziedzicz¹ca po klasie Transaction
public class IncomeTransaction : Transaction
{
    public override void ProcessTransaction()
    {
        // Implementacja dodawania kwoty do ogólnej sumy dochodów
        Account.TotalIncome += Amount;
        Console.WriteLine($"Dodano transakcjê dochodow¹: +{Amount}");
    }
}

// Klasa ExpenseTransaction dziedzicz¹ca po klasie Transaction
public class ExpenseTransaction : Transaction
{
    public override void ProcessTransaction()
    {
        // Implementacja odejmowania kwoty od ogólnej sumy wydatków
        Account.TotalExpenses += Amount;
        Console.WriteLine($"Dodano transakcjê wydatkow¹: -{Amount}");
    }
}

// Klasa Account
public class Account
{
    public static decimal TotalIncome { get; set; }
    public static decimal TotalExpenses { get; set; }
    private List<Transaction> transactions = new List<Transaction>();

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
        transaction.ProcessTransaction();
    }
}

// Przyk³ady u¿ycia
class Program
{
    static void Main()
    {
        Account account = new Account();

        // Dodanie przyk³adowych transakcji
        account.AddTransaction(new IncomeTransaction { Amount = 1000, TransactionDate = DateTime.Now });
        account.AddTransaction(new ExpenseTransaction { Amount = 500, TransactionDate = DateTime.Now });
        account.AddTransaction(new IncomeTransaction { Amount = 2000, TransactionDate = DateTime.Now });

        // Wyœwietlenie ogólnej sumy dochodów i wydatków
        Console.WriteLine($"Ogólna suma dochodów: {Account.TotalIncome}");
        Console.WriteLine($"Ogólna suma wydatków: {Account.TotalExpenses}");
    }
}