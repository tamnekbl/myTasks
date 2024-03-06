
using System.Runtime.InteropServices;
object locker = new();
var account = new Account(1000);
Task[] tasks = new Task[100];
for (int i = 0; i<100; i++)
{
    tasks[i] = Task.Factory.StartNew(() => Update(account));
}

Task.WaitAll(tasks);
System.Console.WriteLine(account.balance); 

void Update (Account acc)
{
    lock(locker)
    {
        acc.Adjust(150);
        acc.Adjust(-150);
        acc.Adjust(-100);
        acc.Adjust(100);
        acc.Adjust(-503);
        acc.Adjust(-14);
        acc.Adjust(503);
        acc.Adjust(14);
        acc.Adjust(5);
        acc.Adjust(5);
    }
    
}
class Account
{

    public int balance;
    public Account(int _balance) => balance = _balance;
    public void Adjust(int amount)
    {
        balance += amount;
    }
}

//проблема https://metanit.com/sharp/tutorial/11.4.php