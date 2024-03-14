
using System.Runtime.InteropServices;

Task[] tasks = new Task [10];

for (int i=0; i<10; i++)
{
    tasks[i] = Task.Run(() => Rand500());
}

int j = Task.WaitAny(tasks);
Console.WriteLine(tasks[j].Id);

void Rand500 ()
{
    Random random = new Random(323);
    int randomValue = random.Next(1000);
    while(randomValue!=500)
    {
        randomValue = random.Next(1000);
        Thread.Sleep(1);
    }
    
}