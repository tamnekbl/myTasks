AutoResetEvent rozetka1 = new AutoResetEvent (true);   //общий ресурс
AutoResetEvent rozetka2 = new AutoResetEvent (true);

Thread[] equipment = new Thread[2]; 

for (int i = 0; i<2; i++)
{
    equipment[i] = new Thread(Guest);
    equipment[i].Start(i);
}

void Guest(object? obj)
{
    if (obj is int id)
    {
        while(true)
        {
            Lunch();
            PushPlugs(id);      
            Work(id);
            PopPlugs(id);
        }
    }
}

void Work (int id)
{
    System.Console.WriteLine($"Компьютер {id}: Я работаю...");
    Random random = new Random();
    int randomValue = random.Next(100, 1010);  
    Thread.Sleep(randomValue);
    
}
void Lunch()
{
    Random random = new Random();
    int randomValue = random.Next(100, 1010);
    Thread.Sleep(randomValue);
}

void PushPlugs(int i)
{
    rozetka1.WaitOne();
    Console.WriteLine($"Компьютер {i}: подключил в верхнюю розетку");

    rozetka2.WaitOne();
    Console.WriteLine($"Компьютер {i}: подключил в нижнюю розетку");
}

void PopPlugs(int i)
{
    Console.WriteLine($"Компьютер {i}: отключил верхнюю розетку");
    rozetka1.Set();
    
    Console.WriteLine($"Компьютер {i}: отключил нижнюю розетку");
    rozetka2.Set();
    
}