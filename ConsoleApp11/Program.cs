
using System.Runtime.InteropServices;

int [] adjusts = {150, -150, -100, 100, -503, -14, 503, 14, 5, 5}; 
var account1 = new Account(1000);
var account2 = new Account(1000);
Task[] tasks = new Task[100];
for (int i = 0; i<100; i++)
{
    tasks[i] = Task.Factory.StartNew(() => Update(account1, account2));
    if (account1.balance+account2.balance != 2000) Console.WriteLine($"Total = {account1.balance}");
}

Task all_tasks = Task.WhenAll(tasks);


Thread.Sleep(0);
//Console.WriteLine($"Total = {account1.balance+account2.balance}");
System.Console.WriteLine(account1.balance); 
System.Console.WriteLine(account2.balance); 



void Update (Account acc1, Account acc2)
{
        foreach (int i in adjusts)
        {
            acc1.Adjust(i);
            acc2.Adjust(-i);
        }
}


class Account
{
    private object locker = new();
    public int balance;
    public Account(int _balance) => balance = _balance;
    public void Adjust(int amount)
    {
        lock(locker)
        {
            balance += amount;
        }
    }
}

//проблема https://metanit.com/sharp/tutorial/11.4.php