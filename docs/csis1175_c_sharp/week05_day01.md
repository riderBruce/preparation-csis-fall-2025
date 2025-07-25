# 📅 Week 05 – Day 1: Object-Oriented Programming in C#

## 🎯 Focus

Build a real-world simulation using C# class design  
**Topic**: Bank Account Simulation (OOP)

---

## 🧠 Concept Goals

- Understand how to model objects in C#
- Practice defining classes with:
  - Properties
  - Constructors
  - Methods
- Learn to instantiate objects and call methods
- Reinforce the concepts of **encapsulation** and **data validation**

---

## 🛠️ Mini Project: Bank Account Simulator

### 🔧 Step-by-step Tasks

1. **Create a Class `BankAccount`**

   - Properties:

     - `AccountHolder` (`string`)
     - `AccountNumber` (`string`)
     - `Balance` (`decimal`, read-only from outside)

   - Constructor:

     - Accepts all 3 values (or `initialBalance` default = 0)

   - Methods:
     - `Deposit(decimal amount)`
     - `Withdraw(decimal amount)`
     - `ShowBalance()`

2. **In `Main()` method**
   - Create multiple `BankAccount` objects
   - Simulate deposits and withdrawals
   - Display results using `ShowBalance()`

---

## 📄 Code Skeleton

```csharp
public class BankAccount
{
    public string AccountHolder { get; set; }
    public decimal Balance { get; private set; }
    public string AccountNumber { get; }

    public BankAccount(string holder, string number, decimal initialBalance)
    {
        AccountHolder = holder;
        AccountNumber = number;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
            Balance -= amount;
        else
            Console.WriteLine("Insufficient funds.");
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Account: {AccountNumber} | Holder: {AccountHolder} | Balance: ${Balance}");
    }
}
```

## ✅ Stretch Goals (Optional)

- Add a transaction history (List of string logs)
- Add a method to transfer money between two accounts
- Add account types (savings/checking) using inheritance
- Add interest calculation for savings account

## 🧠 Reflection Prompts

- How does this example reflect real-world object modeling?
- What benefits does this abstraction give you as a programmer?
- How could you reuse or expand this structure in the future?
