
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

int [] adjusts = {150, -150, -100, 100, -503, -14, 503, 14, 5, 5}; 
var account1 = new Account(1000);
var account2 = new Account(1000);
Task[] tasks = new Task[100];

for (int i = 0; i<100; i++)
{
    tasks[i] = Task.Run(() => Update(account1, account2));
}


Task all_tasks = Task.WhenAll(tasks);

int n = 0;
while(!all_tasks.IsCompleted)
{
    int total_balance = account1.GetBalance() + account2.GetBalance();
    System.Console.WriteLine();
    if (total_balance != 2000)
    {
        System.Console.WriteLine($"Total balance is wrong: {total_balance}");
        n++;
    }
}
System.Console.WriteLine($"Number of mistakes: {n}");



System.Console.WriteLine(account1.GetBalance()); 
System.Console.WriteLine(account2.GetBalance()); 

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

    private int balance;

    public int GetBalance() => balance;
    public Account(int _balance) => balance = _balance;
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
        }
    }
}

//проблема https://metanit.com/sharp/tutorial/11.4.php