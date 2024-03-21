using System;
using System.Threading;

AutoResetEvent mre1 = new AutoResetEvent(false);
AutoResetEvent mre2 = new AutoResetEvent(true);

    Task Task2 = Task.Run(()=>
    {
        
        for (int i = 1; i<=10; i++)
        {
            mre1.WaitOne();
            System.Console.WriteLine("World");
            mre2.Set();
        }
    });

    Task Task1 = Task.Run(()=>
    {
        for (int i = 1; i<=10; i++)
        {
            mre2.WaitOne();
            System.Console.Write("Hello ");
            mre1.Set();

        }
        
    });




    Task.WaitAll(Task1, Task2);

