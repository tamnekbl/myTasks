int [] Input ()
{
    Console.Write("Введите количество чисел: ");
    int n =  Convert.ToInt32(Console.ReadLine());
    int [] arr = new int [n];
    Random rand = new Random();
    for (int i = 0; i < n; i++) arr[i] = rand.Next(100); 
    return arr;
}

int Counter (int [] arr)
{
    int count = 0;
    foreach (int i in arr) count += (i % 2 == 0) ? 1 : 0;
    return count;
}

void Output(int [] arr)
{
    foreach (int i in arr) Console.Write(i + " ");
    Console.WriteLine();
    
}

int [] nums = Input();
Output(nums);
Console.WriteLine("Количество чётных = {0}", Counter(nums));
