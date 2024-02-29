using System;
using System.Threading;

ManualResetEvent manualResetEvent = new ManualResetEvent(false);

Task Task1 = Task.Run(()=>
{
    manualResetEvent.Set();
    System.Console.WriteLine("Hello");
});

Task Task2 = Task.Run(()=>
{
    
    System.Console.WriteLine("World");
    manualResetEvent.WaitOne();
});


Task.WaitAll();