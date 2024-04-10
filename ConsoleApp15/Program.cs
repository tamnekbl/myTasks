
List <bool> forks = new List<bool>(5) {false, false, false, false, false}; //лист левых вилок для проверки дедлока
List <AutoResetEvent> forkEvents = new List <AutoResetEvent> (5);   //общий ресурс

// Инициализируем каждый AutoResetEvent
for (int i = 0; i < 5; i++)
{
    forkEvents.Add(new AutoResetEvent(true)); // true означает, что вилка доступна
}
AutoResetEvent are = new AutoResetEvent(true);

Thread[] philosophers = new Thread[5]; 

for (int i = 0; i<5; i++)
{
    philosophers[i] = new Thread(Guest);
    philosophers[i].Start(i+1);
}

void Guest(object? obj)
{
    if (obj is int id)
    {
        while(true)
        {
            Thinking(id);
            TakeForks(id);      
            Lunch();
            PutForks(id);
        }
    }
}

void Thinking(int id)
{
    System.Console.WriteLine($"Философ {id}: Я думаю...");
    Random random = new Random();
    int randomValue = random.Next(1000, 1010);  //Уменьшил разницу во времени, чтобы вероятнее добиться дедлока
    Thread.Sleep(randomValue);
    
}

void TakeForks(int i)
{
    // Ждем доступности левой вилки
    forkEvents[i - 1].WaitOne();
    forks[i - 1] = true; // В этом массиве мы отмечаем, что взяли именно левую вилку
    Console.WriteLine($"Философ {i}: Я взял левую вилку...");
    
    are.WaitOne();  //критическая секция необходима, чтобы вилку уступил только один философ
    int flag = 0;
    for (int j =0; j<5; j++) if (forks[j] == true) flag++;     //если все взяли по левой вилке, значит дедлок => кто-то уступает вилку
    if (flag == 5) 
    {                                                                          
        forks [i-1] = false;       
        forkEvents[i - 1].Set(); // Сигнализируем, что левая вилка доступна     
        System.Console.WriteLine($"Философ {i}: Я положил обратно и уступил левую вилку...");  
        are.Set();  
        Thread.Sleep(100);
        forkEvents[i - 1].WaitOne();
        forks[i - 1] = true; // Взяли левую вилку снова  
        Console.WriteLine($"Философ {i}: Я взял левую вилку...");                    
    }
    else are.Set();                                       
    
    // Ждем доступности правой вилки
    forkEvents[i % 5].WaitOne();
    Console.WriteLine($"Философ {i}: Я взял правую вилку и кушаю...");
}

void PutForks(int i)
{
    Console.WriteLine($"Философ {i}: Я закончил кушать и положил вилки");
    forks [i-1] = false;  
    forkEvents[i - 1].Set(); // Сигнализируем, что левая вилка доступна
    forkEvents[i % 5].Set(); // Сигнализируем, что правая вилка доступна
}

void Lunch()
{
    Random random = new Random();
    int randomValue = random.Next(1000, 1010);
    Thread.Sleep(randomValue);
}

