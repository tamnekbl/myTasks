
using System.Runtime.InteropServices;
object locker = new();
int [] array = {5, 4, 3, 2, 1}; 

Task[] tasks = new Task [10];

for (int i=0; i<10; i++)
{
    tasks[i] = Task.Factory.StartNew(() => Sort(array));
}

Task.WaitAll(tasks);

foreach (var i in array) System.Console.WriteLine(i);

void Sort (int [] arr)
{
    lock(locker)
    {
        for (int i = 0; i<arr.Length-1; i++)
        {
            if (arr[i] > arr[i+1])
            {
                (arr[i], arr[i+1]) = (arr[i+1], arr[i]);
                break;
            }
        }
    }
    
}

