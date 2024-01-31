
Console.Write("Введите количество чисел: ");
int n =  Convert.ToInt32(Console.ReadLine());
int [] nums = new int [n];

for (int i = 0; i<n; i++) nums[i] = Convert.ToInt32(Console.ReadLine());

int Summator (int [] arr)
{
    int sum = 0;
    foreach (int i in arr) sum += i; 
    return sum;
}

Console.WriteLine("Сумма = {0}", Summator (nums));