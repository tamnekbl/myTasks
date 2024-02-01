using System.Collections;
using System.Numerics;
using Microsoft.VisualBasic;

string [] list = {"6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз"};

string [] must = {"Пик", "Черв", "Крест", "Бубен"};

IEnumerable <string> all_cards = list.Select(x=> must.Select(y=>x+'-'+y)).SelectMany(x=> x);

//foreach (string i in all_cards) Console.WriteLine(i);

 
IEnumerable <IEnumerable <String>> nums2 = list.Select(x=> must.Select(y=>x+'-'+y)).Select(x=> x);;



void Print(IEnumerable list)
{
    foreach (IEnumerable i in list)
    {
        if (i.GetType() == typeof(String)) Console.WriteLine(i);
        else  Print(i);
    }
}

//rjvv

Print (nums2);
