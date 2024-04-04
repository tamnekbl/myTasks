

//List <AutoResetEvent> forks = new List<AutoResetEvent>(5);
List <bool> forks = new List<bool>(5) {false, false, false, false, false}; //общий ресурс

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
    int randomValue = random.Next(100, 5000);
    Thread.Sleep(randomValue);
    
}

void TakeForks(int i)
{
    int k = 0;
    while (k == 0)
    {
        if (forks[i-1] == false) 
        {
            k++;
            forks [i-1] = true;     //взяли левую вилку
        } 
    }
    System.Console.WriteLine($"Философ {i}: Я взял левую вилку...");
    
    while (k == 1)
    {
        if (forks[(3+i)%5] == false) 
        {
            k++;
            forks[(3+i)%5] = true;      //взяли правую вилку
        }
    }
    System.Console.WriteLine($"Философ {i}: Я взял правую вилку и кушаю...");
}

void PutForks(int i)
{
    forks[i-1] = false; 
    forks[(3+i)%5] = false;
    System.Console.WriteLine($"Философ {i}: Я зкончил кушать и положил вилки");
}

void Lunch()
{
    Random random = new Random();
    int randomValue = random.Next(100, 5000);
    Thread.Sleep(randomValue);
}

