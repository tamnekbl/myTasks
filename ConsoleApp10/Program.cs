using System;
using System.Threading;

ManualResetEvent manualResetEvent = new ManualResetEvent(false);

Task Task1 = Task.Run(()=>
{
    System.Console.WriteLine("Hello");
    manualResetEvent.Set();
});

Task Task2 = Task.Run(()=>
{
    manualResetEvent.WaitOne();
    System.Console.WriteLine("World");
    
});


Task.WaitAll(Task1, Task2);