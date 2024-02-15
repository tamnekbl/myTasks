using System.Threading;
 


Param parametr1 = new Param("Main", 200);
Param parametr2 = new Param("Second", 1000);

Thread myThread = new Thread(Print);
myThread.Start(parametr2);
 
Print(parametr1);
 

Console.WriteLine("Программа завершилась.");

void Print(object? obj)
{
    if (obj is Param prt)
    {
        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine($"Поток {prt.ThreadName}: {i}");
            Thread.Sleep(prt.SleepValue);
        }
        Console.WriteLine($"Вывод из потока {prt.ThreadName} завершился.");
    }
    
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