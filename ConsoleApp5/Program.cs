using System.Collections;

string [] list = {"6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз"};

string [] must = {"Пик", "Черв", "Крест", "Бубен"};

IEnumerable <string> all_cards = list.Select(x=> must.Select(y=>x+'-'+y)).SelectMany(x=> x);

IEnumerable <string> Shuffle (IEnumerable <string> input, int n)
{
    List <string> result = input.ToList();
    Random rand = new Random();

    for (int i = 0; i<n; i++)
    {
        int count = result.Count();
        while (count > 1)
        {
            count --;
            int index = rand.Next(count + 1);
            string tmp = result[count];
            result[count] = result[index];
            result[index] = tmp;
        }
    }

    return result;
}

IEnumerable<IEnumerable<string>> Batch (IEnumerable<string> input, int n)
{
    List<string> batch = new List<string> (n);
    foreach (var i in input)
    {
        batch.Add(i);
        
        if (batch.Count == n)
        {
            yield return batch;
            batch = new List<string> (n);
        }
    }
}

void Print(IEnumerable list)
{
    foreach (IEnumerable i in list)
    {
        if (i.GetType() == typeof(String)) Console.Write(i+"  ");
        else  Print(i);
    }
    Console.WriteLine();
}

all_cards = Shuffle (all_cards, 5);

Print (Batch(all_cards, 6).Take(6));


