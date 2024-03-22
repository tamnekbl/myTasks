
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

int [] adjusts = {150, -150, -100, 100, -503, -14, 503, 14, 5, 5}; 
var account1 = new Account(1000);
var account2 = new Account(1000);
Task[] tasks = new Task[100];

for (int i = 0; i<100; i++)
{
     if (i%2 == 1)  tasks[i] = Task.Run(() => Update(account1, account2));
     else tasks[i] = Task.Run(() => Update(account2, account1));
}


Task all_tasks = Task.WhenAll(tasks);

int n = 0;
while(!all_tasks.IsCompleted)
{
    if (Account.total_balance != 2000)
    {
        System.Console.WriteLine($"Total balance is wrong: {Account.total_balance}");
        n++;
    }
    
}
System.Console.WriteLine($"Number of mistakes: {n}");
System.Console.WriteLine(Account.total_balance); 



void Update (Account acc1, Account acc2)
{
    foreach (int i in adjusts)
    {
        acc1.Adjust(acc2, i);
    }
}


class Account
{
    static object locker = new object();
    public static int total_balance;    
    private int balance;

    public int GetBalance() => balance;
    public Account(int _balance)
    {
        balance = _balance;
        total_balance += balance;   //в конструкторе сразу прибавляем к статическому полю баланс, т.к. при первом вызове в основной программе total_balance = 0
    }

    int TotalBalance(Account source) => GetBalance() + source.GetBalance(); 

    public void Adjust(int amount)
    {
        lock(locker)
        {
            balance += amount;
        }
    }
    public void Adjust(Account source, int amount)
    {
        lock(locker)
        {
            balance += amount;
            source.Adjust(-amount);
            total_balance = TotalBalance(source);
        }
    }
}

