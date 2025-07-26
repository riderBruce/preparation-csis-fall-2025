using System;

public class Program
{
    public static void Main(string[] args)
    {
        BankAccount bankAccountNo1 = new BankAccount("John", "1111-1", 5000);
        SavingAccount bankAccountNo2 = new SavingAccount("John", "1112-1", 3000);

        bankAccountNo1.Withdraw(300);
        bankAccountNo2.Deposit(500);

        decimal transferAmount = 500;
        BankManager.TransferMoney(transferAmount, bankAccountNo1, bankAccountNo2);

        bankAccountNo2.CalculateInterest();

        bankAccountNo1.ShowBalance();
        bankAccountNo2.ShowBalance();
    }
}
public static class BankManager
{
    public static void TransferMoney(decimal amount, BankAccount accountFrom, BankAccount accountTo)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Input a positive amount.");
            return;
        }

        accountFrom.Withdraw(amount);
        accountFrom.WriteLog($"Transferred ${amount} to {accountTo.AccountHolder} ({accountTo.AccountNumber})");

        accountTo.Deposit(amount);
        accountTo.WriteLog($"Transferred ${amount} from {accountFrom.AccountHolder} ({accountFrom.AccountNumber})");

    }
}

public class BankAccount
{
    public string AccountHolder { get; set; }
    public decimal Balance { get; protected set; }
    public string AccountNumber { get; }
    public List<string> AccountLogs { get; private set; } = new List<string>();
    public BankAccount(string holder, string number, decimal initialBalance)
    {
        AccountHolder = holder;
        AccountNumber = number;
        Balance = initialBalance;
    }
    public void Deposit(decimal amount)
    {
        Balance += amount;
        string log = $"Deposit: {amount:C} {new string('-', 20)} Balance: {Balance:C}";
        WriteLog(log);
    }
    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }
            
        Balance -= amount;
        string log = $"Withdraw: -{amount:C} {new string('-', 20)} Balance: {Balance:C}";
        WriteLog(log);
    }

    public virtual void ShowBalance()
    {
        Console.WriteLine($"Account: {AccountNumber} | Holder: {AccountHolder} | Balance: ${Balance}");
        if (AccountLogs.Count > 0)
        {
            foreach (string log in AccountLogs)
            {
                Console.WriteLine(log);
            }
        }
        Console.WriteLine(new string('-', 60));
    }
    public void WriteLog(string log)
    {
        AccountLogs.Add(log);
    }
}

public class SavingAccount : BankAccount
{
    public decimal InterestRate { get; private set; }
    public SavingAccount(string holder, string number, decimal initialBalance) : base(holder, number, initialBalance)
    {
        InterestRate = 5; // Default interest rate
    }

    public void CalculateInterest()
    {
        decimal interest = Balance * InterestRate / 100;
        Balance += interest;
        WriteLog($"Deposit (Interest earned): ${interest} {new string('-', 20)} Balance: {Balance:C}");
        
    }
    public override void ShowBalance()
    {
        base.ShowBalance();
        Console.WriteLine($"Interest Rate: {InterestRate}%");
    }
}
