using MyContainer;
using MyContainer.MyStack;


MyStack<int> stack = new MyStack<int>();

Random rand = new Random();
for (int i = 0; i < 10; i++) stack.Push(rand.Next(5)); 

Task<int> myThread = Task.Run(()=>Sum(stack));
Task printTask = myThread.ContinueWith(task => Console.WriteLine($"Поток: {task.Result}"));

Console.WriteLine($"Основная программа: {Sum(stack)}");
 

myThread.Wait();
Console.WriteLine("Программа завершилась.");



int Sum(object? obj)
{
    int sum = 0;
    
    if (obj is MyStack<int> stack)
    {
        IEnumerator iterator = stack.GetIterator();
        if (iterator != null)
        {
            while (iterator.MoveNext())
            {
                sum += Convert.ToInt32(iterator.Current());;
                Console.WriteLine($"Текущая сумма: {sum}");
                Thread.Sleep(10);
            }
            
        }
    }
    return sum;
}
