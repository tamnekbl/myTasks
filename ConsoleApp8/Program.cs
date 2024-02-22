using System.Diagnostics.CodeAnalysis;
using System.Threading;
 


Param parametr1 = new Param("Main", 200);
Param parametr2 = new Param("Second", 1000);


Task<int> myThread = Task.Run(()=>Print(parametr2));
Task printTask = myThread.ContinueWith(task => Console.WriteLine($"Sum: {task.Result}"));

Print(parametr1);
 

myThread.Wait();
Console.WriteLine("Программа завершилась.");



int Print(object? obj)
{
    int sum = 0;
    if (obj is Param prt)
    {
        for (int i = 1; i < 11; i++)
        {
            sum+=i;
            Console.WriteLine($"Поток {prt.ThreadName}: {i}");
            Thread.Sleep(prt.SleepValue);
        }
        Console.WriteLine($"Вывод из потока {prt.ThreadName} завершился.");
    }
    return sum;
}

public struct Param
{
    public string ThreadName;
    public int SleepValue;
    public Param(string name, int value)
    {
        ThreadName = name;
        SleepValue = value;
    }
}
