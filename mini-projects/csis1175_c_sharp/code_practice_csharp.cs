using System;
public class BankAccount
{
    public string AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public decimal Balance { get; private set; }
    public BankAccount(string accountHolderName, string accountNumber, decimal initialBalance)
    {
        AccountHolderName = accountHolderName;
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }
    
}