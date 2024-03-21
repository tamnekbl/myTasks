
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

int [] adjusts = {150, -150, -100, 100, -503, -14, 503, 14, 5, 5}; 
var account1 = new Account(1000);
var account2 = new Account(1000);
Task[] tasks = new Task[100];
for (int j = 1; j<=50; j++)
{
for (int i = 0; i<100; i++)
{
    tasks[i] = Task.Run(() => Update(account1));
}


Task.WaitAll(tasks);

System.Console.WriteLine(account1.GetBalance());

void Update (Account acc1)
{
    foreach (int i in adjusts)
    {
        
        acc1.Adjust(i);
        
    }
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
        lock(locker){
        balance += amount;
        }
    }

}

//проблема https://metanit.com/sharp/tutorial/11.4.php